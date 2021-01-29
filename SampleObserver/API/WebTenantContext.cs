using Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace API
{
    public class WebTenantContext : ITenantContext
    {
        private readonly IHttpContextAccessor _accessor;
        public WebTenantContext(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Tenant => (string)_accessor.HttpContext?.GetRouteData().Values["tenant"] ?? string.Empty;
    }
}