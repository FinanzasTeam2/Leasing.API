using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class SolutionRepository:BaseRepository,ISolutionRepository
{
    public SolutionRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<Solution>> ListAsync()
    {
        return await _context.Solution.ToListAsync();
    }

    public Task AddAsync(Solution solution)
    {
        await _context.Solution.AddAsync(solution);
    }

    public Task<Solution> FindByIdAsync(int id)
    {
        return await _context.Solution.FindAsync(id);
    }

    public void Update(Solution solution)
    {
        _context.Solution.Update(solution);
    }

    public void Remove(Solution solution)
    {
        _context.Solution.Remove(solution);
    }
}