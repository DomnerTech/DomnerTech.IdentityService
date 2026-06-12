using DomnerTech.IdentityService.Application.IRepo;
using DomnerTech.IdentityService.Domain.Entities;
using DomnerTech.IdentityService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DomnerTech.IdentityService.Infrastructure.Repo;

public sealed class UserRepo(IdentityDbContext dbContext) : IUserRepo
{
    public async Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<UserEntity?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users
            .FirstOrDefaultAsync(x => x.Username == username, cancellationToken);
    }

    public async Task AddAsync(UserEntity user, CancellationToken cancellationToken = default)
    {
        await dbContext.Users
            .AddAsync(user, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}