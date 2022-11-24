using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class LeasingDataRepository : BaseRepository, ILeasingDataRepository
    {
        public LeasingDataRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LeasingData>> ListAsync()
        {
            return await _context.LeasingData.ToListAsync();
        }

        public async Task AddAsync(LeasingData leasingData)
        {
            await _context.LeasingData.AddAsync(leasingData);
        }

        public async Task<LeasingData> FindByIdAsync(int id)
        {
            return await _context.LeasingData.FindAsync(id);
        }
        
        
        public async Task<LeasingData> GetLastLeasingDataId()
        {
            return await _context.LeasingData.LastOrDefaultAsync();
        }

        
        public async Task<IEnumerable<LeasingData>> FindByUserIdAsync(int userId)
        {
            return await _context.LeasingData
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }
    }
}