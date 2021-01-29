using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Interfaces
{
    // As API is suppose to write (or is it?) and Service is suppose to read, we may want to split it in to 2 different interfaces.
    public interface ITimeSeriesRepository
    {
        Task<IEnumerable<double>> GetTimeSeriesAsync(long? from, long? to);

        Task SaveTimeSeriesAsync(params TimeSeriesRecord[] records);
    }
}