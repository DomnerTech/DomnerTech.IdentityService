using DomnerTech.IdentityService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DomnerTech.IdentityService.Infrastructure.Services;

public static class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo<IBaseService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        return services;
    }
}