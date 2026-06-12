using DomnerTech.IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomnerTech.IdentityService.Infrastructure.Persistence;

public sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users => Set<UserEntity>();

    public DbSet<ApplicationEntity> Applications => Set<ApplicationEntity>();

    public DbSet<RoleEntity> Roles => Set<RoleEntity>();

    public DbSet<PermissionEntity> Permissions => Set<PermissionEntity>();
    public DbSet<UserApplicationRoleEntity> UserApplicationRoles => Set<UserApplicationRoleEntity>();

    public DbSet<RolePermissionEntity> RolePermissions => Set<RolePermissionEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
        modelBuilder.UseOpenIddict();
        base.OnModelCreating(modelBuilder);
    }
}