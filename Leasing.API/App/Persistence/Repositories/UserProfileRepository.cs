using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task AddAsync(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
        }

        public async Task<UserProfile> FindByIdAsync(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public void Update(UserProfile userProfile)
        {
            _context.UserProfiles.Update(userProfile);
        }

        public void Remove(UserProfile userProfile)
        {
            _context.UserProfiles.Remove(userProfile);
        }
    }
}