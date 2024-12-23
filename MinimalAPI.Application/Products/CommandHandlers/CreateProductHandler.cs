using MediatR;
using MinimalAPI.Application.Interfaces;
using MinimalAPI.Application.Products.Commands;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, Product>
    {
        private readonly IProductRepository _prodRep;

        public CreateProductHandler(IProductRepository prodRep)
        {
            _prodRep = prodRep;
        }
        public async Task<Product> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Qnt = request.Qnt,
                Price = request.Price,
            };
            return await _prodRep.CreateProduct(newProduct);
        }
    }
}
