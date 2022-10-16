



using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}