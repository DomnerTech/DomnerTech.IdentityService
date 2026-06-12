using DomnerTech.IdentityService.Domain.Common;

namespace DomnerTech.IdentityService.Domain.Entities;

public sealed class UserEntity : AuditableEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public ICollection<UserApplicationRole> ApplicationRoles = [];
}