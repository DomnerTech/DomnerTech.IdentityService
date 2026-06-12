namespace DomnerTech.IdentityService.Domain.Entities;

public sealed class RolePermissionEntity
{
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
    public RoleEntity Role { get; set; } = new();
    public PermissionEntity Permission { get; set; } = new();
}