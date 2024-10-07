using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleo.EventBus.Cap;

public static class CapEventExtension
{
    public static void AddCapEventBus(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddCap(options =>
        {
            options.UseMongoDB(opt =>
            {
                opt.DatabaseConnection = configuration["DatabaseSettings:ConnectionString"];
                opt.DatabaseName = configuration["DatabaseSettings:DatabaseName"];
            });

            options.UseRabbitMQ(opt =>
            {
                opt.HostName = configuration["RabbitMQ:HostName"];
                opt.UserName = configuration["RabbitMQ:UserName"];
                opt.Password = configuration["RabbitMQ:Password"];
            });

            options.UseDashboard(opt => { opt.PathMatch = "/cap"; });
            options.FailedRetryCount = 6;
            options.FailedRetryInterval = 60;
        });

        services.AddSingleton<IEventBus, CapEventBus>();
    }

    public static void AddCapEventBus(this IServiceCollection services,DotNetCore.CAP.CapOptions options)
    {
        services.AddCap(opt => 
        {
            opt = options;
        });

        services.AddSingleton<IEventBus, CapEventBus>();
    } 
}
