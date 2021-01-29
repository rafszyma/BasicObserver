using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SampleObserver.API
{
    public class WebTenantContext : ITenantContext
    {
        private readonly IHttpContextAccessor _accessor;
        public WebTenantContext(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        
        public string Tenant()
        {
            var tenant = (string)_accessor.HttpContext?.GetRouteData().Values["tenant"];
            return tenant ?? string.Empty;
        }
    }
}