using Application;
using Common.Bases;
using System.Reflection;

namespace WebApi.Dependency;

public static class DependencyExtensions
{
    public static IServiceCollection RegisterWebApi(this IServiceCollection Services)
    {
        Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        Services.Scan(scan => scan.FromAssembliesOf(typeof(ApplicationAssembly))
                                              .AddClasses(classes => classes.AssignableTo<ITransient>())
                                              .AsImplementedInterfaces()
                                              .WithTransientLifetime()
                               );
        return Services;
    }
}
