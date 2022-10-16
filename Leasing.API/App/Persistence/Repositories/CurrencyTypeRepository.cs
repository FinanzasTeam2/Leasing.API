using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class CurrencyTypeRepository:BaseRepository,ICurrencyTypeRepository
{
    public CurrencyTypeRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<CurrencyType>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(CurrencyType currencyType)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyType> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(CurrencyType currencyType)
    {
        throw new NotImplementedException();
    }

    public void Remove(CurrencyType currencyType)
    {
        throw new NotImplementedException();
    }
}