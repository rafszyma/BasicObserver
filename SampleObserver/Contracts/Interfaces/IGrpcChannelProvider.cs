using Grpc.Net.Client;

namespace Contracts.Interfaces
{
    public interface IGrpcChannelProvider
    {
        GrpcChannel GetChannel();
    }
}