using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class RateTypeRepository:BaseRepository,IRateTypeRepository
{
    public RateTypeRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<RateType>> ListAsync()
    {
        return await _context.RateType.ToListAsync();
    }

    public Task AddAsync(RateType rateType)
    {
        await _context.RateType.AddAsync(rateType);
    }

    public Task<RateType> FindByIdAsync(int id)
    {
        return await _context.RateType.FindAsync(id);
    }

    public void Update(RateType rateType)
    {
        _context.RateType.Update(rateType);
    }

    public void Remove(RateType rateType)
    {
        _context.RateType.Remove(rateType);
    }
}