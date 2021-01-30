using System.Linq;
using System.Threading.Tasks;
using CalculationService;
using Contracts.Interfaces;
using Grpc.Core;

namespace Service.Services
{
    public class CalculationService : Calculate.CalculateBase
    {
        private readonly ITimeSeriesQueryRepository _timeSeriesQueryRepository;

        public CalculationService(ITimeSeriesQueryRepository timeSeriesQueryRepository)
        {
            _timeSeriesQueryRepository = timeSeriesQueryRepository;
        }
        
        public override async Task<CalculateResponse> CalculateTimePeriod(CalculateRequest request, ServerCallContext context)
        {
            var series = (await _timeSeriesQueryRepository.GetTimeSeriesAsync(request.From, request.To)).ToArray();
            return new CalculateResponse
            {
                Average = series.Average(),
                Sum = series.Sum()
            };
        }
    }
}