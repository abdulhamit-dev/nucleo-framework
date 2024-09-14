namespace Nucleo.Cache;

public class CacheSettings
{
    public string Provider { get; set; }
    public int DbIndex { get; set; }
    public string CachePrefix { get; set; }
    public RedisSentinelSettings RedisSentinel { get; set; }
}

public class RedisSentinelSettings
{
    public string MasterName { get; set; }
    public string Password { get; set; }
    public List<string> SentinelHosts { get; set; }
}