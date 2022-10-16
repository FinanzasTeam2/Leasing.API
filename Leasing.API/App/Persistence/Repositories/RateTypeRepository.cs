using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class RateTypeRepository:BaseRepository,IRateTypeRepository
{
    public RateTypeRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<RateType>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(RateType rateType)
    {
        throw new NotImplementedException();
    }

    public Task<RateType> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(RateType rateType)
    {
        throw new NotImplementedException();
    }

    public void Remove(RateType rateType)
    {
        throw new NotImplementedException();
    }
}