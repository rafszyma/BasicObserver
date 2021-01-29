using System.Threading.Tasks;
using Contracts;
using Contracts.Interfaces;

namespace CalculationService.Repositories
{
    public class MongoRepository : IRepository
    {
        private readonly ITenantContext _tenantContext;

        public MongoRepository(ITenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }

        public Task<double[]> GetTimeSeriesAsync(long? from, long? to)
        {
            throw new System.NotImplementedException();
        }
    }
}