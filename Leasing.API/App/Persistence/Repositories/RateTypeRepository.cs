using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class RateTypeRepository : BaseRepository, IRateTypeRepository
    {
        public RateTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RateType>> ListAsync()
        {
            return await _context.RateTypes.ToListAsync();
        }

        public async Task AddAsync(RateType rateType)
        {
            await _context.RateTypes.AddAsync(rateType);
        }

        public async Task<RateType> FindByIdAsync(int id)
        {
            return await _context.RateTypes.FindAsync(id);
        }

        public void Update(RateType rateType)
        {
            _context.RateTypes.Update(rateType);
        }

        public void Remove(RateType rateType)
        {
            _context.RateTypes.Remove(rateType);
        }
    }
}