

using Leasing.API.App.Shared.Persistence.Contexts;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Persistence.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }


    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}