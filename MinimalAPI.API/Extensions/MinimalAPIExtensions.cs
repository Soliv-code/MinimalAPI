using Microsoft.EntityFrameworkCore;
using MinimalAPI.API.Interfaces;
using MinimalAPI.Application.Interfaces;
using MinimalAPI.Application.Products.Commands;
using MinimalAPI.Infrastructure;
using MinimalAPI.Infrastructure.Repositories;

namespace MinimalAPI.API.Extensions
{
    public static class MinimalAPIExtensions
    {

        public static void RegisterDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ProdDbContext>(opt 
                => opt.UseSqlServer(builder.Configuration.GetConnectionString("ProdDb")));
        }
        public static void RegisterRepository(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
        public static void RegisterMediatR(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateProduct).Assembly);
            });
        }
        public static void RegisterEndpointDefinitions(this WebApplication app)
        {
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();
            foreach (var endpointDef in endpointDefinitions)
            {
                endpointDef.RegisterEndpoints(app);
            }
        }
    }
}
