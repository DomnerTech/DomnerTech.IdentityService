using DomnerTech.IdentityService.Application;
using DomnerTech.IdentityService.Infrastructure.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace DomnerTech.IdentityService.Infrastructure.Caching;
public static class Extensions
{
    public static IServiceCollection AddCache(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddRedis(appSettings);
        return services;
    }
}
