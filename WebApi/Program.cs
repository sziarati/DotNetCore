using Application;
using Application.Dependency;
using Core.Interfaces;
using FluentValidation.AspNetCore;
using Infra;
using Infra.Accounts.Repository;
using Infra.Interceptors;
using Infra.Users.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Dependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddControllers()
    .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining(typeof(Program)));
builder.Services.AddDbContext<appDbContext>(
        option => option.UseSqlServer(builder.Configuration["ConnectionStrings:default"])
                        .AddInterceptors(new mySaveChangesInterceptor())
    );
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services
    .RegisterWebApi()
    .RegisterApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

app.Run();
