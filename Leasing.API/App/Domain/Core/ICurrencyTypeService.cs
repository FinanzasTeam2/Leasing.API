using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface ICurrencyTypeService
{
    Task<IEnumerable<CurrencyType>> ListAsync();
    Task<CurrencyType> FindByIdAsync(int id);
}