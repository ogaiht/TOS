using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Security.Authentication;
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
                    MongoClientSettings mongoClientSettings;
                    if (settings.UseCosmos)
                    {
                        mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.ConnectionString));
                        mongoClientSettings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                    }
                    else
                    {
                        mongoClientSettings = MongoClientSettings.FromConnectionString(new MongoConnectionStringBuilder().Build(settings));
                    }
                    //string connectionString = new MongoConnectionStringBuilder().Build(settings);                    

                    IMongoClient mongoClient = new MongoClient(mongoClientSettings);
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
        string ConnectionString { get; }
        bool UseCosmos { get; }
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }
        public bool UseCosmos { get; set; }
    }
}
