using Grpc.Core;
using Inventory.gRPC.Protos;

namespace Inventory.gRPC.Services
{
    public class ExistenceService : Existence.ExistenceBase
    {
        public override Task<productExistenceReply> checkExistence(productRequest request, ServerCallContext context)
        {
            // logica de negocios va aqui
            return Task.FromResult(new productExistenceReply() { ProductQTY = 12 });
        }
    }
}
