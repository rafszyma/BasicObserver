using System.Threading.Tasks;
using Contracts.Models;

namespace SampleObserver.API.Services
{
    public interface ITimeSeriesService
    {
        Task<(double average, double sum)> GetTimeSeriesStatsAsync(long? from, long? to);

        Task SubmitTimeSeriesData(TimeSeriesRecord[] records);
    }
}