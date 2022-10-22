using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class CurrencyTypeRepository:BaseRepository,ICurrencyTypeRepository
{
    public CurrencyTypeRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<CurrencyType>> ListAsync()
    {
        return await _context.CurrencyType.ToListAsync();
    }

    public Task AddAsync(CurrencyType currencyType)
    {
        await _context.CurrencyType.AddAsync(currencyType);
    }

    public Task<CurrencyType> FindByIdAsync(int id)
    {
        return await _context.CurrencyType.FindAsync(id);
    }

    public void Update(CurrencyType currencyType)
    {
        _context.CurrencyType.Update(currencyType);
    }

    public void Remove(CurrencyType currencyType)
    {
        _context.CurrencyType.Remove(currencyType);
    }
}