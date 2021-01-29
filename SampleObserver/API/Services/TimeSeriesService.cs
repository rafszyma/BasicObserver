using System.Threading.Tasks;
using CalculationService;
using Contracts.Interfaces;
using Contracts.Models;
using SampleObserver.API.Client;
using SampleObserver.API.Services;

namespace API.Services
{
    public class TimeSeriesService : ITimeSeriesService
    {
        private readonly Calculate.CalculateClient _client;

        private readonly ITimeSeriesCommandRepository _commandRepository;

        public TimeSeriesService(ITimeSeriesChannelProvider channelProvider,
            ITimeSeriesCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
            _client = new Calculate.CalculateClient(channelProvider.GetChannel());
        }

        public async Task<(double average, double sum)> GetTimeSeriesStatsAsync(long? from, long? to)
        {
            var response = await _client.CalculateTimePeriodAsync(new CalculateRequest
            {
                From = from ?? long.MinValue,
                To = to ?? long.MaxValue
            });
            return (response.Average, response.Sum);
        }

        public async Task SubmitTimeSeriesData(TimeSeriesModel[] records)
        {
            await _commandRepository.SaveTimeSeriesAsync(records);
        }
    }
}