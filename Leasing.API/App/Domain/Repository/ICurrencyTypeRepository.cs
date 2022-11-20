using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface ICurrencyTypeRepository
{
    Task<IEnumerable<CurrencyType>> ListAsync();
    Task<CurrencyType> FindByIdAsync(int id);
}