using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using MongoDB.Driver;

namespace Shared.Repository
{
    public class MongoTimeSeriesQueryRepository : MongoRepository, ITimeSeriesQueryRepository

    {
        protected MongoTimeSeriesQueryRepository(ITenantContext tenantContext, IMongoClient client) : base(
            tenantContext, client)
        {
        }

        public async Task<IEnumerable<double>> GetTimeSeriesAsync(long from, long to)
        {
            return (await GetTimeSeriesCollection().FindAsync(x => x.T > from && x.T < to)).Current.Select(x => x.V);
        }
    }
}