using System.Threading.Tasks;

namespace CalculationService.Repositories
{
    public interface IRepository
    {
        Task<double[]> GetTimeSeriesAsync(long? from, long? to);
    }
}