using System.Net.Http;
using Contracts;
using Grpc.Net.Client;

namespace SampleObserver.API.Client
{
    public class TimeSeriesChannelProvider : ITimeSeriesChannelProvider
    {
        private GrpcChannel _channel;

        private readonly IBasicConfiguration _configuration;

        private readonly HttpMessageHandler _tenantHttpHandler;
        
        public TimeSeriesChannelProvider(IBasicConfiguration configuration,  ITenantHttpHandler tenantHttpHandler)
        {
            _configuration = configuration;
            _tenantHttpHandler = tenantHttpHandler as HttpMessageHandler;
        }
        
        public GrpcChannel GetChannel()
        {
            
            return _channel ??= GrpcChannel.ForAddress(_configuration.CalculationServiceUrl, new GrpcChannelOptions
            {
                HttpHandler = _tenantHttpHandler
            });
        }
    }
}