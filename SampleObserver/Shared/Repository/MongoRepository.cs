using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Contracts.Interfaces;
using Contracts.Models;
using MongoDB.Driver;

namespace Shared.Repository
{
    public class MongoTimeSeriesRepository : ITimeSeriesRepository
    {
        private readonly ITenantContext _tenantContext;

        private readonly IMongoClient _client;

        public MongoTimeSeriesRepository(ITenantContext tenantContext, IMongoClient client)
        {
            _tenantContext = tenantContext;
            _client = client;
        }

        public async Task<IEnumerable<double>> GetTimeSeriesAsync(long from, long to)
        {
            return (await GetTimeSeriesCollection().FindAsync(x => x.T > from && x.T < to)).Current.Select(x => x.V);
        }

        public async Task SaveTimeSeriesAsync(params TimeSeriesModel[] records)
        {
            await GetTimeSeriesCollection().InsertManyAsync(records.Select(x => new TimeSeriesDocument
            {
                T = x.T,
                V = x.V
            }));
        }

        // TODO make it more generic
        private IMongoCollection<TimeSeriesDocument> GetTimeSeriesCollection()
        {
            return _client.GetDatabase(_tenantContext.Tenant)
                .GetCollection<TimeSeriesDocument>(Collections.TimeSeries.ToString());
        }
    }
}