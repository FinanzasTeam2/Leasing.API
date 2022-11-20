using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories;

public class LeasingMethodRepository:BaseRepository,ILeasingMethodRepository
{
    public LeasingMethodRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<LeasingMethod>> ListAsync()
    {
        return await _context.LeasingMethods.ToListAsync();
    }

    public async Task<LeasingMethod> FindByIdAsync(int id)
    {
        return await _context.LeasingMethods.FindAsync(id);
    }
}