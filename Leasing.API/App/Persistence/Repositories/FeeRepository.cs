using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class FeeRepository:BaseRepository,IFeeRepository
{
    public FeeRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<Fee>> ListAsync()
    {
        return await _context.Fee.ToListAsync();
    }

    public Task AddAsync(Fee fee)
    {
        await _context.Fee.AddAsync(fee);
    }

    public Task<Fee> FindByIdAsync(int id)
    {
        return await _context.Fee.FindAsync(id);
    }

    public void Update(Fee fee)
    {
        _context.Fee.Update(fee);
    }

    public void Remove(Fee fee)
    {
        _context.Fee.Remove(fee);
    }
}