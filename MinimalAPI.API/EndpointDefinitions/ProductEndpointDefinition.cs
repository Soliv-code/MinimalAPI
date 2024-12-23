using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.API.Filters;
using MinimalAPI.API.Interfaces;
using MinimalAPI.Application.Products.Commands;
using MinimalAPI.Application.Products.Queries;

namespace MinimalAPI.API.EndpointDefinitions
{
    public class ProductEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var productsGroup = app.MapGroup("/api/products");

            productsGroup.MapGet("/", GetAllProducts)
                .WithName("GetAllProducts");

            productsGroup.MapGet("/{id}", GetProductById)
                .WithName("GetProductById");

            productsGroup.MapPost("/", CreateProduct)
                .AddEndpointFilter<ProductCreateValidationFilter>();

            productsGroup.MapPut("/{id}", UpdateProduct)
                .AddEndpointFilter<ProductUpdateValidationFilter>();

            productsGroup.MapDelete("/{id}", DeleteProduct);
        }

        private async Task<IResult> GetAllProducts(IMediator mediatoR)
        {
            var getProducts = new GetAllProducts();
            var products = await mediatoR.Send(getProducts);
            if (products is null) return Results.NotFound("Not found any products!");
            return TypedResults.Ok(products);
        }

        private async Task<IResult> GetProductById(IMediator mediatoR, int id)
        {
            if (id <= 0) return TypedResults.BadRequest("Product id can't be less or equals zero");
            var getProduct = new GetProductById { ProductId = id };
            var product = await mediatoR.Send(getProduct);
            if (product is null) return Results.NotFound($"Product with id: {id} not found!");
            return TypedResults.Ok(product);
        }

        private async Task<IResult> CreateProduct(IMediator mediatoR, [FromBody] CreateProduct _product)
        {
            var createdProduct = await mediatoR.Send(_product);
            return Results.CreatedAtRoute("GetProductById", new { createdProduct.Id }, createdProduct);
        }

        private async Task<IResult> UpdateProduct(IMediator mediatoR, [FromBody] UpdateProduct _product, int id)
        {
            if (id <= 0) return TypedResults.BadRequest("Product id can't be less or equals zero");
            _product.ProductId = id;
            var updatedProduct = await mediatoR.Send(_product);
            if (updatedProduct is null) TypedResults.NotFound($"Product with id: {id} not found!");
            return TypedResults.Ok(updatedProduct);
        }

        private async Task<IResult> DeleteProduct(IMediator mediatoR, int id)
        {
            bool isDeleted = await mediatoR.Send(new DeleteProduct { ProductId = id });
            if (!isDeleted) return TypedResults.NotFound($"Product with id: {id} not found!");
            return TypedResults.Ok($"Product Id: {id} successfully removed");
        }


    }
}
