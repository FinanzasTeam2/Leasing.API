using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Resources;
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
        
        public async Task<UserProfile> FindByIdAsync(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public async Task<UserProfile> FindByEmailAndPasswordAsync(string email, string password)
        {
            var userProfile =  _context.UserProfiles.
                Where(u=>u.Email == email && u.Password==password)
                .FirstOrDefault();

            return userProfile;
        }

        public async Task AddAsync(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
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