using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories;

public class TimeRepository:BaseRepository,ITimeRepository
{
    public TimeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Time>> ListAsync()
    {
        return await _context.Times.ToListAsync();
    }

    public async Task<Time> FindByIdAsync(int id)
    {
        return await _context.Times.FindAsync(id);
    }
}