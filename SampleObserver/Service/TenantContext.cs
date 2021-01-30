using Contracts.Interfaces;

namespace Service
{
    public class GrpcTenantContext : ITenantContext
    {
        public string Tenant { get; set; }
    }
}