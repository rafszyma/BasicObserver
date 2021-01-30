using Contracts;
using Contracts.Interfaces;
using MongoDB.Driver;

namespace Shared.Persistence
{
    public abstract class SharedMongoRepository
    {
        private readonly ITenantContext _tenantContext;

        private readonly IMongoClient _client;

        protected SharedMongoRepository(ITenantContext tenantContext, IMongoClient client)
        {
            _tenantContext = tenantContext;
            _client = client;
        }

        protected IMongoCollection<TimeSeriesDocument> GetTimeSeriesCollection(string tenant = null)
        {
            return _client.GetDatabase(tenant ?? _tenantContext.Tenant)
                .GetCollection<TimeSeriesDocument>(Collections.TimeSeries.ToString());
        }
    }
}