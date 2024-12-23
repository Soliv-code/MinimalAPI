using MediatR;

namespace MinimalAPI.Application.Products.Commands
{
    public class DeleteProduct : IRequest<bool>
    {
        public int ProductId { get; set; }
    }
}
