using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class UserProfileRepository:BaseRepository,IUserProfileRepository
{
    public UserProfileRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<UserProfile>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(UserProfile userProfile)
    {
        throw new NotImplementedException();
    }

    public Task<UserProfile> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UserProfile userProfile)
    {
        throw new NotImplementedException();
    }

    public void Remove(UserProfile userProfile)
    {
        throw new NotImplementedException();
    }
}