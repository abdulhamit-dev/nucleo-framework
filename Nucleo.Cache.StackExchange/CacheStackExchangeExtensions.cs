using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Nucleo.Cache.StackExchange;

public static class CacheStackExchangeExtensions
{
    public static IServiceCollection AddCacheRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        var cacheSettings = configuration.GetSection("CacheSettings").Get<CacheSettings>();
        services.Configure<CacheSettings>(configuration.GetSection("CacheSettings"));
        services.TryAddSingleton<ICacheClient, StackExchangeRedisCacheClient>();
        return services;
    }
}