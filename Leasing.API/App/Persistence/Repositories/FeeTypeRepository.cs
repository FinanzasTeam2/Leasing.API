using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class FeeTypeRepository:BaseRepository,IFeeTypeRepository
{
    public FeeTypeRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<FeeType>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(FeeType feeType)
    {
        throw new NotImplementedException();
    }

    public Task<FeeType> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(FeeType feeType)
    {
        throw new NotImplementedException();
    }

    public void Remove(FeeType feeType)
    {
        throw new NotImplementedException();
    }
}