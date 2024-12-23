using MediatR;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.Commands
{
    public class CreateProduct : IRequest<Product> // Получается что это и есть DTO 
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public required int Qnt { get; set; }
        public required decimal Price { get; set; }
    }
}
