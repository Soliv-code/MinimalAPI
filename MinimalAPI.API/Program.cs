using MinimalAPI.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Extensions/MinimalAPIExtensions.cs
builder.RegisterDbContext();    
builder.RegisterRepository();   
builder.RegisterMediatR();      

var app = builder.Build();

// Extensions/MinimalAPIExtensions.cs
// EndpointDefinitions/EndpointDefinition.cs
app.RegisterEndpointDefinitions();  
                                    

app.UseHttpsRedirection();
app.Run();
