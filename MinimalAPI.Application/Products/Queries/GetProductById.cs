using MediatR;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.Queries
{
    public class GetProductById : IRequest<Product>
    {
        public int ProductId { get; set; }
    }
}
