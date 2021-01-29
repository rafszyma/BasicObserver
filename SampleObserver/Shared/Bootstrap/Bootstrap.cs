using Contracts;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Shared.Bootstrap
{
    public static class Bootstrap
    {
        public static IServiceCollection AddMongo(this IServiceCollection serviceCollection, BasicConfiguration config)
        {
            var conString =
                $"mongodb://{config.Mongo.Login}:{config.Mongo.Password}@{config.Mongo.Url}/?authSource=admin";
            var client = new MongoClient(conString);
            /*var client = new MongoClient(new MongoClientSettings
            {
                Server = MongoServerAddress.Parse(config.Mongo.Url),
                Credential =
                    MongoCredential.CreateCredential(config.Mongo.Database, config.Mongo.Login, config.Mongo.Password),

            });*/
            serviceCollection.AddSingleton<IMongoClient>(client);
            return serviceCollection;
        }

        public static IServiceCollection AddConfigProvider(this IServiceCollection serviceCollection, BasicConfiguration config)
        {
            serviceCollection.AddSingleton(config);
            return serviceCollection;
        }
    }
}