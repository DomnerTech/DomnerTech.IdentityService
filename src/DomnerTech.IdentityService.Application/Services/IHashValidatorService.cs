namespace DomnerTech.IdentityService.Application.Services;

public interface IHashValidatorService : IBaseService
{
    bool InvalidSha1(string clientHash, string serverPlainHash, long ts);
}