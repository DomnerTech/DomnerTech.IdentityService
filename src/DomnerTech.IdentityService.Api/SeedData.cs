using DomnerTech.IdentityService.Application.Services;
using DomnerTech.IdentityService.Domain.Entities;
using DomnerTech.IdentityService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DomnerTech.IdentityService.Api;

public static class SeedData
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
        if (await db.Users.AnyAsync())
            return;
        var hasher = scope.ServiceProvider.GetRequiredService<IPasswordHasherService>();
        var admin = new UserEntity("admin", "admin@domnertech.com", hasher.Hash("Admin@123"));
        db.Users.Add(admin);
        await db.SaveChangesAsync();
    }
}