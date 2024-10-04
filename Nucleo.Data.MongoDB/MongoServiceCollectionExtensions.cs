using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Nucleo.Data.MongoDB
{
    public static class MongoServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbRepositories(this IServiceCollection services, string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            services.AddSingleton<IMongoDatabase>(database);
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            return services;
        }

        public static IServiceCollection AddMongoCollection<T>(this IServiceCollection services, string collectionName) where T : class
        {
            services.AddScoped<IMongoCollection<T>>(sp =>
            {
                var database = sp.GetRequiredService<IMongoDatabase>();
                return database.GetCollection<T>(collectionName);
            });

            return services;
        }
    }
}
