using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface ITimeSeriesQueryRepository
    {
        Task<IEnumerable<double>> GetTimeSeriesAsync(long from, long to);
    }
}