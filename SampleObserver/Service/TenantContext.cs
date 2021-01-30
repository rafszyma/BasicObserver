using Contracts.Interfaces;

namespace CalculationService
{
    public class GrpcTenantContext : ITenantContext
    {
        public string Tenant { get; set; }
    }
}