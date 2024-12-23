using MinimalAPI.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Extensions/MinimalAPIExtensions.cs
builder.RegisterDbContext();    
builder.RegisterRepository();   
builder.RegisterMediatR();      

var app = builder.Build();


app.Use(async (ctx, next) =>
{
    try
    {
        await next();
    }
    catch (Exception) 
    { 
        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsync($"An error occurred, please contact the developers\nStatusCode: {ctx.Response.StatusCode}");
    }
});




// Extensions/MinimalAPIExtensions.cs
// EndpointDefinitions/EndpointDefinition.cs
app.RegisterEndpointDefinitions();  
                                    

app.UseHttpsRedirection();
app.Run();
