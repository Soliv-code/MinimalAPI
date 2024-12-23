using MediatR;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.Commands
{
    public class UpdateProduct : IRequest<Product>
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public required int Qnt { get; set; }
        public required decimal Price { get; set; }
    }
}
