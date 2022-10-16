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
        throw new NotImplementedException();
    }

    public Task AddAsync(Period period)
    {
        throw new NotImplementedException();
    }

    public Task<Period> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Period period)
    {
        throw new NotImplementedException();
    }

    public void Remove(Period period)
    {
        throw new NotImplementedException();
    }
}