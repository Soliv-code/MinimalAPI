using MediatR;
using MinimalAPI.Application.Interfaces;
using MinimalAPI.Application.Products.Queries;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.QueryHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById, Product?>
    {
        private readonly IProductRepository _prodRep;

        public GetProductByIdHandler(IProductRepository prodRep) => _prodRep = prodRep;
        public async Task<Product?> Handle(GetProductById request, CancellationToken cancellationToken)
            => await _prodRep.GetProductById(request.ProductId);
    }
}
