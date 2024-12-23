using MediatR;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Products.Queries
{
    public class GetAllProducts : IRequest<ICollection<Product>>
    {
    }
}
