using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class UserRepository:BaseRepository,IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<User>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }

    public void Remove(User user)
    {
        throw new NotImplementedException();
    }
}