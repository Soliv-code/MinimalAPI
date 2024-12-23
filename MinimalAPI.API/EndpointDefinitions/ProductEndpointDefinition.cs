using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            productsGroup.MapGet("/", async (IMediator mediatoR) =>
            {
                var getProducts = new GetAllProducts();
                var products = await mediatoR.Send(getProducts);
                if (products is null) return Results.NotFound("Not found any products!");
                return Results.Ok(products);
            })
                .WithName("GetAllProducts");

            productsGroup.MapGet("/{id}", async (IMediator mediatoR, int id) =>
            {
                var getProduct = new GetProductById { ProductId = id };
                var product = await mediatoR.Send(getProduct);
                if (product is null) return Results.NotFound($"Product with id: {id} not found!");
                return Results.Ok(product);
            })
                .WithName("GetProductById");

            productsGroup.MapPost("/", async (IMediator mediatoR, [FromBody] CreateProduct _product) =>
            {
                var createdProduct = await mediatoR.Send(_product);
                return Results.CreatedAtRoute("GetProductById", new { createdProduct.Id }, createdProduct);
            });

            productsGroup.MapPut("/{id}", async (IMediator mediatoR, [FromBody] UpdateProduct _product, int id) =>
            {
                _product.ProductId = id;
                var updatedProduct = await mediatoR.Send(_product);
                if (updatedProduct is null) Results.NotFound($"Product with id: {id} not found!");
                return Results.Ok(updatedProduct);
            });

            productsGroup.MapDelete("/{id}", async (IMediator mediatoR, int id) =>
            {
                bool isDeleted = await mediatoR.Send(new DeleteProduct { ProductId = id });
                if (!isDeleted) return Results.NotFound($"Product with id: {id} not found!");
                return Results.Ok($"Product Id: {id} successfully removed");
            });
        }
    }
}
