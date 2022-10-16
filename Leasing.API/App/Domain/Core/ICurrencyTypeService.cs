using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface ICurrencyTypeService
{
    Task<IEnumerable<CurrencyType>> ListAsync();
    Task<CurrencyTypeResponse> SaveAsync(CurrencyType currencyType);
    Task<CurrencyTypeResponse> UpdateAsync(int id, CurrencyType currencyType);
    Task<CurrencyTypeResponse> DeleteAsync(int id);
}