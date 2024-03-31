using Infra;
using Infra.Interceptors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddControllers();
builder.Services.AddDbContext<appDbContext>(
        option => option.UseSqlServer(builder.Configuration["ConnectionStrings:default"])
                        .AddInterceptors(new mySaveChangesInterceptor())
    );

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

app.Run();
