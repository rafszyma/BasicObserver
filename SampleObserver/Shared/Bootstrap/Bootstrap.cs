using Contracts;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Shared.Bootstrap
{
    public static class Bootstrap
    {
        public static IServiceCollection AddMongo(this IServiceCollection serviceCollection, IBasicConfiguration config)
        {
            serviceCollection.AddSingleton<IMongoClient>(new MongoClient(config.MongoUrl));
            return serviceCollection;
        }

        public static IServiceCollection AddConfigProvider(this IServiceCollection serviceCollection, IBasicConfiguration config)
        {
            serviceCollection.AddSingleton(config);
            return serviceCollection;
        }
    }
}