using MediatR;
using MinimalAPI.Application.Interfaces;
using MinimalAPI.Application.Products.Commands;

namespace MinimalAPI.Application.Products.CommandHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, bool>
    {
        private IProductRepository _prodRep;

        public DeleteProductHandler(IProductRepository prodRep) => _prodRep = prodRep;
        public async Task<bool> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            return await _prodRep.DeleteProduct(request.ProductId);
        }
    }
}
