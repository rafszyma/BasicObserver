using System.Threading.Tasks;
using Contracts.Models;

namespace SampleObserver.API.Services
{
    public class TimeSeriesService : ITimeSeriesService
    {
        // Send it using gRPC
        public  Task<(double average, double sum)> GetTimeSeriesStatsAsync(long? from, long? to)
        {
            throw new System.NotImplementedException();
        }

        public Task SubmitTimeSeriesData(TimeSeriesRecord[] records)
        {
            throw new System.NotImplementedException();
        }
    }
}