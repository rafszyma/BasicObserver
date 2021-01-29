using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace CalculationService
{
    public class TenantInterceptor : Interceptor
    {
        private readonly GrpcTenantContext _tenantContext;

        public TenantInterceptor(GrpcTenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }

        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            _tenantContext.Tenant = context.RequestHeaders.GetValue("tenant");
            return base.UnaryServerHandler(request, context, continuation);
        }
    }
}