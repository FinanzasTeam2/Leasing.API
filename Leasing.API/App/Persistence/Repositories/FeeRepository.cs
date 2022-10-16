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
        throw new NotImplementedException();
    }

    public Task AddAsync(Fee fee)
    {
        throw new NotImplementedException();
    }

    public Task<Fee> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Fee fee)
    {
        throw new NotImplementedException();
    }

    public void Remove(Fee fee)
    {
        throw new NotImplementedException();
    }
}