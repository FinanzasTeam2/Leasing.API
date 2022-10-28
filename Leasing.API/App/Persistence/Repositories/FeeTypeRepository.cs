using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class FeeTypeRepository : BaseRepository, IFeeTypeRepository
    {
        public FeeTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FeeType>> ListAsync()
        {
            return await _context.FeeTypes.ToListAsync();
        }

        public async Task AddAsync(FeeType feeType)
        {
            await _context.FeeTypes.AddAsync(feeType);
        }

        public async Task<FeeType> FindByIdAsync(int id)
        {
            return await _context.FeeTypes.FindAsync(id);
        }

        public void Update(FeeType feeType)
        {
            _context.FeeTypes.Update(feeType);
        }

        public void Remove(FeeType feeType)
        {
            _context.FeeTypes.Remove(feeType);
        }
    }
}