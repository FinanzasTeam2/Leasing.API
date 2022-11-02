using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class PeriodRepository : BaseRepository, IPeriodRepository
    {
        public PeriodRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Period>> ListAsync()
        {
            return await _context.Periods.ToListAsync();
        }

        public async Task AddAsync(Period period)
        {
            await _context.Periods.AddAsync(period);
        }

        public async Task<Period> FindByIdAsync(int id)
        {
            return await _context.Periods.FindAsync(id);
        }

        public void Update(Period period)
        {
            _context.Periods.Update(period);
        }

        public void Remove(Period period)
        {
            _context.Periods.Remove(period);
        }

        public async Task<IEnumerable<Period>> FindByTimeIdAsync(int timeId)
        {
            return await _context.Periods
                .Where(p => p.TimeId == timeId)
                .Include(p => p.Time)
                .ToListAsync();
        }
    }
}