using MediatR;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.Commands
{
    public class UpdateProduct : IRequest<Product>
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Qnt { get; set; }
        public decimal Price { get; set; }
    }
}
