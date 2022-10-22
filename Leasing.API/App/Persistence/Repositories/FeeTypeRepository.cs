using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class FeeTypeRepository:BaseRepository,IFeeTypeRepository
{
    public FeeTypeRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<FeeType>> ListAsync()
    {
        return await _context.FeeType.ToListAsync();
    }

    public Task AddAsync(FeeType feeType)
    {
        await _context.FeeType.AddAsync(feeType);
    }

    public Task<FeeType> FindByIdAsync(int id)
    {
        return await _context.FeeType.FindAsync(id);
    }

    public void Update(FeeType feeType)
    {
        _context.FeeType.Update(feeType);
    }

    public void Remove(FeeType feeType)
    {
        _context.FeeType.Remove(feeType);
    }
}