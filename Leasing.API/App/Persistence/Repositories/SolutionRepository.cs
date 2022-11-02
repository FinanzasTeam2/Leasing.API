using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class SolutionRepository : BaseRepository, ISolutionRepository
    {
        public SolutionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Solution>> ListAsync()
        {
            return await _context.Solutions.ToListAsync();
        }

        public async Task AddAsync(Solution solution)
        {
            await _context.Solutions.AddAsync(solution);
        }

        public async Task<Solution> FindByIdAsync(int id)
        {
            return await _context.Solutions.FindAsync(id);
        }

        public void Update(Solution solution)
        {
            _context.Solutions.Update(solution);
        }

        public void Remove(Solution solution)
        {
            _context.Solutions.Remove(solution);
        }

        public async Task<IEnumerable<Solution>> FindByUserProfileIdAsync(int userprofileId)
        {
            return await _context.Solutions
                .Where(p => p.UserProfileId == userprofileId)
                .Include(p => p.UserProfile)
                .ToListAsync();
        }
    }
}