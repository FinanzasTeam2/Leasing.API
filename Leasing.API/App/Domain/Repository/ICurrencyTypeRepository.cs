using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface ICurrencyTypeRepository
{
    Task<IEnumerable<CurrencyType>> ListAsync();
    Task AddAsync(CurrencyType currencyType);
    Task<CurrencyType> FindByIdAsync(int id);
    void Update(CurrencyType currencyType);
    void Remove(CurrencyType currencyType);
}