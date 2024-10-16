using Microsoft.Extensions.Configuration;
using Nucleo.DDD.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Nucleo.DDD.CrossCuttingConcerns.Serilog.Messages;
using Serilog;

namespace Nucleo.DDD.CrossCuttingConcerns.Serilog.Logger;

public class MongoDbLogger : LoggerServiceBase
{
    public MongoDbLogger(IConfiguration configuration)
    {
        MongoDbConfiguration logConfiguration =
            configuration.GetSection("SeriLogConfigurations:MongoDbConfiguration").Get<MongoDbConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);
        
        var seriLogConfig = new LoggerConfiguration()
            .WriteTo.MongoDB(logConfiguration.ConnectionString, logConfiguration.CollectionName)
            .CreateLogger();

        Logger = seriLogConfig;
    }
}