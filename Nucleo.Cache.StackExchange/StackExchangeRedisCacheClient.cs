using System.Text.Json;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Nucleo.Cache.StackExchange;

public class StackExchangeRedisCacheClient : ICacheClient
{
    private static IDatabase _database;
    private readonly CacheSettings _cacheSettings;
    private readonly ILogger<StackExchangeRedisCacheClient> _logger;
    private Lazy<ConnectionMultiplexer> _connection;

    public StackExchangeRedisCacheClient(CacheSettings cacheSettings, ILogger<StackExchangeRedisCacheClient> logger,
        Lazy<ConnectionMultiplexer> connection)
    {
        _cacheSettings = cacheSettings;
        _logger = logger;
        _connection = connection;
        InitRedis(_cacheSettings);
    }

    public async Task<bool> DeleteAsync(string key)
    {
        var cacheKey = $"{_cacheSettings.CachePrefix}:{key}";
        try
        {
            var result = false;
            result = await _database.KeyDeleteAsync(cacheKey);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("failed to delete cache item {key} {Ex}", cacheKey, ex);
            return false;
        }
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var cacheKey = $"{_cacheSettings.CachePrefix}:{key}";
        try
        {
            string itemJson = await _database.StringGetAsync(cacheKey);
            var item = !string.IsNullOrWhiteSpace(itemJson) ? JsonSerializer.Deserialize<T>(itemJson) : default;
            return item;
        }
        catch (Exception ex)
        {
            _logger.LogError("failed to get cache item {key} {Ex}", cacheKey, ex);
            return default;
        }
    }

    public async Task AddOrUpdateAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var cacheKey = $"{_cacheSettings.CachePrefix}:{key}";
        try
        {
            var itemJson = JsonSerializer.Serialize(value);
            await _database.StringSetAsync(cacheKey, itemJson, expiry);
        }
        catch (Exception ex)
        {
            _logger.LogError("failed to set cache item {key} {Ex}", cacheKey, ex);
            throw;
        }
    }

    private void InitRedis(CacheSettings cacheSettings)
    {
        var options = new ConfigurationOptions
        {
            KeepAlive = 60,
            AbortOnConnectFail = false,
            AllowAdmin = true,
            Password = cacheSettings.RedisSentinel.Password,
            ServiceName = cacheSettings.RedisSentinel.MasterName
        };

        cacheSettings.RedisSentinel.SentinelHosts.ForEach(host => { options.EndPoints.Add(host); });
        _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
        _database = _connection.Value.GetDatabase(cacheSettings.DbIndex);
    }
}