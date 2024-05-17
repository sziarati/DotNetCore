using Application.Dependency;
using WebApi.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterWebApi(builder.Configuration)
    .RegisterServices()
    .RegisterApplication()
    .RegisterEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
});

app.MapEndpoints();

app.Run();
