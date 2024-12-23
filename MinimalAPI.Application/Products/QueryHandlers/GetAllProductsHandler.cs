using MediatR;
using MinimalAPI.Application.Interfaces;
using MinimalAPI.Application.Products.Queries;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.QueryHandlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, ICollection<Product>>
    {
        private readonly IProductRepository _prodRep;

        public GetAllProductsHandler(IProductRepository prodRep) => _prodRep = prodRep;

        public Task<ICollection<Product>> Handle(GetAllProducts request, CancellationToken cancellationToken) => _prodRep.GetAllProducts();
    }
}
