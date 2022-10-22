using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class PeriodRepository:BaseRepository,IPeriodRepository
{
    public PeriodRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<Period>> ListAsync()
    {
        return await _context.Period.ToListAsync();
    }

    public Task AddAsync(Period period)
    {
        await _context.Period.AddAsync(period);
    }

    public Task<Period> FindByIdAsync(int id)
    {
        return await _context.Period.FindAsync(id);
    }

    public void Update(Period period)
    {
        _context.Period.Update(period);
    }

    public void Remove(Period period)
    {
        _context.Period.Remove(period);
    }
}