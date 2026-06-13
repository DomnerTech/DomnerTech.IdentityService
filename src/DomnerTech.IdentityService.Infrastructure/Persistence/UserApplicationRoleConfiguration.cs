using DomnerTech.IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomnerTech.IdentityService.Infrastructure.Persistence;

public sealed class UserApplicationRoleConfiguration : IEntityTypeConfiguration<UserApplicationRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserApplicationRoleEntity> builder)
    {
        builder.ToTable("UserApplicationRoles");

        builder.HasKey(uar => new { uar.UserId, uar.ApplicationId, uar.RoleId });

        builder.HasOne(uar => uar.User)
            .WithMany(u => u.ApplicationRoles)
            .HasForeignKey(uar => uar.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(uar => uar.Application)
            .WithMany()
            .HasForeignKey(uar => uar.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(uar => uar.Role)
            .WithMany()
            .HasForeignKey(uar => uar.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}