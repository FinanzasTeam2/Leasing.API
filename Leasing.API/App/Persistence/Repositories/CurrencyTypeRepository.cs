using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{
    public class CurrencyTypeRepository : BaseRepository, ICurrencyTypeRepository
    {
        public CurrencyTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CurrencyType>> ListAsync()
        {
            return await _context.CurrencyTypes.ToListAsync();
        }


        public async Task<CurrencyType> FindByIdAsync(int id)
        {
            return await _context.CurrencyTypes.FindAsync(id);
        }
    }
}