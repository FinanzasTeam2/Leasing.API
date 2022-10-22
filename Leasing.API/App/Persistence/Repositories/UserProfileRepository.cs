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
        return await _context.UserProfile.ToListAsync();
    }

    public Task AddAsync(UserProfile userProfile)
    {
        await _context.UserProfile.AddAsync(userProfile);
    }

    public Task<UserProfile> FindByIdAsync(int id)
    {
        return await _context.UserProfile.FindAsync(id);
    }

    public void Update(UserProfile userProfile)
    {
        _context.UserProfile.Update(userProfile);
    }

    public void Remove(UserProfile userProfile)
    {
        _context.UserProfile.Remove(userProfile);
    }
}