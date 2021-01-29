using System.Threading.Tasks;
using Contracts;

namespace SampleObserver.API.DataProvider
{
    public interface ITimeSeriesService
    {
        Task<(double average, double sum)> GetTimeSeriesStatsAsync(long? from, long? to);

        Task SubmitTimeSeriesData(TimeSeriesRecord[] records);
    }
}