namespace DomnerTech.IdentityService.Domain.Entities;

public sealed class RoleEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<RolePermissionEntity> Permissions = [];
}