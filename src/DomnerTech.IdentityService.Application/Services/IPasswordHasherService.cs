namespace DomnerTech.IdentityService.Application.Services;

public interface IPasswordHasherService : IBaseService
{
    string Hash(string password);
    bool Verify(string password, string hash);
}