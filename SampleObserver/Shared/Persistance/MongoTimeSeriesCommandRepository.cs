using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Contracts.Models;
using MongoDB.Driver;

namespace Shared.Repository
{
    public class MongoTimeSeriesCommandRepository : SharedMongoRepository, ITimeSeriesCommandRepository
    {
        public MongoTimeSeriesCommandRepository(ITenantContext tenantContext, IMongoClient client) : base(tenantContext,
            client)
        {
        }

        public async Task SaveTimeSeriesAsync(params TimeSeriesModel[] records)
        {
            var dictionary = records.GroupBy(x => x.Tenant)
                .ToDictionary(x => x.Key,
                    x => x.ToList().Select(y => (y.T, y.V)));
            foreach (var (tenant, values) in dictionary)
            {
                await GetTimeSeriesCollection(tenant).InsertManyAsync(values.Select(x =>
                    new TimeSeriesDocument
                    {
                        T = x.T,
                        V = x.V
                    }));
            }
        }
    }
}