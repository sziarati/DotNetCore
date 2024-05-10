using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Dependency;

public static class DependencyExtensions
{
    public static IServiceCollection RegisterApplication(this IServiceCollection Services)
    {
        Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return Services;
    }
}
