namespace DomnerTech.IdentityService.Domain.Entities;

public sealed class UserApplicationRoleEntity
{
    public Guid UserId { get; set; }
    public Guid ApplicationId { get; set; }
    public Guid RoleId { get; set; }
    public UserEntity User { get; set; } = null!;
    public ApplicationEntity Application { get; set; } = new();
    public RoleEntity Role { get; set; } = new();
}