namespace Nucleo.DDD.CrossCuttingConcerns.Serilog.ConfigurationModels;

public class MongoDbConfiguration
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }

    public MongoDbConfiguration()
    {
        ConnectionString = string.Empty;
        DatabaseName = string.Empty;
        CollectionName = string.Empty;
    }

    public MongoDbConfiguration(string connectionString, string databaseName, string collectionName)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
        CollectionName = collectionName;
    }
}