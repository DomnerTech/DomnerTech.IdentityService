using DomnerTech.IdentityService.Domain.Entities;

namespace DomnerTech.IdentityService.Application.IRepo;

public interface IUserRepo : IBaseRepo
{
    Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserEntity?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task AddAsync(UserEntity user, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}