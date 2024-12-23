using MediatR;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.Commands
{
    public class CreateProduct : IRequest<Product> // Получается что это и есть DTO 
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Qnt { get; set; }
        public decimal Price { get; set; }
    }
}
