namespace Nucleo.Cache;

public interface ICacheClient
{
    Task<bool> DeleteAsync(string key);
    Task<T> GetAsync<T>(string key);
    Task AddOrUpdateAsync<T>(string key, T value, TimeSpan? expiry = null);
}