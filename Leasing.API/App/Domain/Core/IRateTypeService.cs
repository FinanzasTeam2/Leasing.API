using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IRateTypeService
{
    Task<IEnumerable<RateType>> ListAsync();
    Task<RateTypeResponse> SaveAsync(RateType rateType);
    Task<RateTypeResponse> UpdateAsync(int id, RateType rateType);
    Task<RateTypeResponse> DeleteAsync(int id);
}