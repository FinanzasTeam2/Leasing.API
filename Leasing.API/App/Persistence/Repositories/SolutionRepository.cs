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
        throw new NotImplementedException();
    }

    public Task AddAsync(Solution solution)
    {
        throw new NotImplementedException();
    }

    public Task<Solution> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Solution solution)
    {
        throw new NotImplementedException();
    }

    public void Remove(Solution solution)
    {
        throw new NotImplementedException();
    }
}