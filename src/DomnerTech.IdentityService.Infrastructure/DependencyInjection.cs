using DomnerTech.IdentityService.Application;
using DomnerTech.IdentityService.Application.Services;
using DomnerTech.IdentityService.Infrastructure.Caching;
using DomnerTech.IdentityService.Infrastructure.Persistence;
using DomnerTech.IdentityService.Infrastructure.Repo;
using DomnerTech.IdentityService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DomnerTech.IdentityService.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddCache(appSettings)
            .AddRepo()
            .AddServices();

        services.AddHttpContextAccessor();
        services.AddScoped<ICorrelationContext, CorrelationContext>();
        services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseSqlServer(appSettings.ConnectionStrings.IdentityDb);

            options.UseOpenIddict();
        });
    }
}