using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class LeasingResultRepository : BaseRepository, ILeasingResultRepository
    {
        public LeasingResultRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LeasingResult>> ListAsync()
        {
            return await _context.LeasingResults.ToListAsync();
        }

        public async Task AddAsync(LeasingResult leasingResult)
        {
            await _context.LeasingResults.AddAsync(leasingResult);
        }

        public async Task<LeasingResult> FindByIdAsync(int id)
        {
            return await _context.LeasingResults.FindAsync(id);
        }
        
        public async Task<IEnumerable<LeasingResult>> FindByLeasingDataIdAsync(int leasingDataId)
        {
            return await _context.LeasingResults
                .Where(p => p.LeasingDataId == leasingDataId)
                .Include(p => p.LeasingDataId)
                .ToListAsync();
        }
    }
}