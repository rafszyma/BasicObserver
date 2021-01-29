using System.Threading.Tasks;
using Contracts.Models;

namespace API.Services
{
    public interface ITimeSeriesService
    {
        Task<(double average, double sum)> GetTimeSeriesStatsAsync(long? from, long? to);

        Task SubmitTimeSeriesData(TimeSeriesModel[] records);
    }
}