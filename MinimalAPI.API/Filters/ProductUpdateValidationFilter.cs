using Microsoft.IdentityModel.Tokens;
using MinimalAPI.Application.Products.Commands;

namespace MinimalAPI.API.Filters
{
    public class ProductUpdateValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var product = context.GetArgument<UpdateProduct>(1);
            if (product.Name.IsNullOrEmpty()) 
                return await Task.FromResult(Results.BadRequest("Product name is required parameter! Can't be null or empty!"));
            if(product.Price <= 0 )
                return await Task.FromResult(Results.BadRequest("Product price cannot be less than or equal to zero"));
            if(product.Qnt <= 0)
                return await Task.FromResult(Results.BadRequest("Product quantity cannot be less than or equal to zero"));
            return await next(context);
        }
    }
}
