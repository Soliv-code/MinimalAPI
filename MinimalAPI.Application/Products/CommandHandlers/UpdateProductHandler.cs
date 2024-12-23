using MediatR;
using MinimalAPI.Application.Interfaces;
using MinimalAPI.Application.Products.Commands;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.CommandHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, Product>
    {
        private readonly IProductRepository _prodRep;

        public UpdateProductHandler(IProductRepository prodRep) => _prodRep = prodRep; // Using primary constructor!
        public async Task<Product> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var updateProd = new Product
            {
                Id = request.ProductId,
                Name = request.Name,
                Description = request.Description,
                Qnt = request.Qnt,
                Price = request.Price
            };
            var product = await _prodRep.UpdateProduct(request.ProductId, updateProd);
            return updateProd;
        }
    }
}
