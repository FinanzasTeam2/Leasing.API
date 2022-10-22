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
        return await _context.User.ToListAsync();
    }

    public Task AddAsync(User user)
    {
        await _context.User.AddAsync(user);
    }

    public Task<User> FindByIdAsync(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public void Update(User user)
    {
        _context.User.Update(user);
    }

    public void Remove(User user)
    {
        _context.User.Remove(user);
    }
}