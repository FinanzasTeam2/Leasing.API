using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IFeeTypeService
{
    Task<IEnumerable<FeeType>> ListAsync();
    Task<FeeTypeResponse> SaveAsync(FeeType feeType);
    Task<FeeTypeResponse> UpdateAsync(int id, FeeType feeType);
    Task<FeeTypeResponse> DeleteAsync(int id);
}