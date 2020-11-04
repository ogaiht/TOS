using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TOS.Common.Configuration;
using TOS.Data.MongoDB;

namespace TOS.NiceReads.Configuration
{
    internal static class MongoConfiguration
    {
        internal static IServiceCollection AddMongoDb(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            IDatabaseSettings databaseSettings = configuration.GetConfig<DatabaseSettings>();
            return serviceCollection
                .AddSingleton(databaseSettings)
                .AddScoped<IMongoDatabase>(factory =>
                {
                    IDatabaseSettings settings = factory.GetService<IDatabaseSettings>();
                    string connectionString = new MongoConnectionStringBuilder().Build(settings);
                    IMongoClient mongoClient = new MongoClient(connectionString);
                    IMongoDatabase mongoDatabase = mongoClient.GetDatabase(settings.Database);
                    return mongoDatabase;
                })
                .AddSingleton<ICollectionNameProvider, CollectionNameProvider>()
                .AddScoped<IDatabaseProvider, DatabaseProvider>();            
        }
    }

    public class MongoConnectionStringBuilder
    {
        public string Build(IDatabaseSettings databaseSettings)
        {
            return $@"mongodb://{databaseSettings.User}:{databaseSettings.Password}@{databaseSettings.Host}:{databaseSettings.Port}";
        }
    }

    public interface IDatabaseSettings
    {
        string Database { get; }
        string Host { get; }
        int Port { get; }
        string User { get; }
        string Password { get; }
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
