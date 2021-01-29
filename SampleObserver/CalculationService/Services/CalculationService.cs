using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Grpc.Core;

namespace CalculationService.Services
{
    public class CalculationService : Calculate.CalculateBase
    {
        private readonly ITimeSeriesRepository _timeSeriesRepository;

        public CalculationService(ITimeSeriesRepository timeSeriesRepository)
        {
            _timeSeriesRepository = timeSeriesRepository;
        }
        public override async Task<CalculateResponse> CalculateTimePeriod(CalculateRequest request, ServerCallContext context)
        {
            var series = (await _timeSeriesRepository.GetTimeSeriesAsync(request.From, request.To)).ToArray();
            return new CalculateResponse
            {
                Average = series.Average(),
                Sum = series.Sum()
            };
        }
    }
}