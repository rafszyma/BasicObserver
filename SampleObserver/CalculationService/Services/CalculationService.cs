using System.Linq;
using System.Threading.Tasks;
using CalculationService.Repositories;
using Grpc.Core;

namespace CalculationService.Services
{
    public class CalculationService : Calculate.CalculateBase
    {
        private readonly IRepository _repository;

        public CalculationService(IRepository repository)
        {
            _repository = repository;
        }
        public override async Task<CalculateResponse> CalculateTimePeriod(CalculateRequest request, ServerCallContext context)
        {
            var series = await _repository.GetTimeSeriesAsync(request.From, request.To);
            return new CalculateResponse
            {
                Average = series.Average(),
                Sum = series.Sum()
            };
        }
    }
}