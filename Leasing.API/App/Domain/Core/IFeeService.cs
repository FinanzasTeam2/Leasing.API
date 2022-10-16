using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IFeeService
{
    Task<IEnumerable<Fee>> ListAsync();
    Task<FeeResponse> SaveAsync(Fee fee);
    Task<FeeResponse> UpdateAsync(int id, Fee fee);
    Task<FeeResponse> DeleteAsync(int id);
}