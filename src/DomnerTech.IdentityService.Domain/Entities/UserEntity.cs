using DomnerTech.IdentityService.Domain.Common;

namespace DomnerTech.IdentityService.Domain.Entities;

public sealed class UserEntity : AuditableEntity
{
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    public ICollection<UserApplicationRoleEntity> ApplicationRoles = [];

    private UserEntity() { }

    public UserEntity(
        string username,
        string email,
        string passwordHash)
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = true;
        CreatedAtUtc = DateTime.UtcNow;
    }
}