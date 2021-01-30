using System;
using System.Net.Http;
using Contracts;
using Grpc.Net.Client;

namespace API.Client
{
    public class TimeSeriesChannelProvider : ITimeSeriesChannelProvider
    {
        private GrpcChannel _channel;

        private readonly BasicConfiguration _configuration;

        private readonly HttpMessageHandler _tenantHttpHandler;
        
        public TimeSeriesChannelProvider(BasicConfiguration configuration,  ITenantHttpHandler tenantHttpHandler)
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