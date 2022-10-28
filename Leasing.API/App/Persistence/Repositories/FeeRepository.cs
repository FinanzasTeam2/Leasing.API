using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class FeeRepository : BaseRepository, IFeeRepository
    {
        public FeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Fee>> ListAsync()
        {
            return await _context.Fees.ToListAsync();
        }

        public async Task AddAsync(Fee fee)
        {
            await _context.Fees.AddAsync(fee);
        }

        public async Task<Fee> FindByIdAsync(int id)
        {
            return await _context.Fees.FindAsync(id);
        }

        public void Update(Fee fee)
        {
            _context.Fees.Update(fee);
        }

        public void Remove(Fee fee)
        {
            _context.Fees.Remove(fee);
        }
    }
}