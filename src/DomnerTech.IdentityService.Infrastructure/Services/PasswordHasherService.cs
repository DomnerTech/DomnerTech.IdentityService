using DomnerTech.IdentityService.Application.Services;

namespace DomnerTech.IdentityService.Infrastructure.Services;

public sealed class PasswordHasherService : IPasswordHasherService
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}