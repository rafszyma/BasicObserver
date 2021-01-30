using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Contracts.Interfaces;

namespace API.Client
{
    public class TenantHttpHandler : DelegatingHandler, ITenantHttpHandler
    {
        private readonly ITenantContext _tenantContext;
        public TenantHttpHandler(ITenantContext tenantContext)
        {
            _tenantContext = tenantContext;
            InnerHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
        }
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("tenant", _tenantContext.Tenant);
            return base.SendAsync(request, cancellationToken);
        }
    }
}