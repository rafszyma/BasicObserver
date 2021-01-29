using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface ITimeSeriesCommandRepository
    {
        Task SaveTimeSeriesAsync(params TimeSeriesModel[] records);
    }
}