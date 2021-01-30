using Contracts;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Shared.Bootstrap
{
    public static class Bootstrap
    {
        public static IServiceCollection AddMongo(this IServiceCollection serviceCollection, BasicConfiguration config)
        {
            serviceCollection.AddSingleton<IMongoClient>(new MongoClient(
                $"mongodb://{config.Mongo.Login}:{config.Mongo.Password}@{config.Mongo.Url}/?authSource=admin"));
            return serviceCollection;
        }

        public static IServiceCollection AddConfigProvider(this IServiceCollection serviceCollection,
            BasicConfiguration config)
        {
            serviceCollection.AddSingleton(config);
            return serviceCollection;
        }
    }
}