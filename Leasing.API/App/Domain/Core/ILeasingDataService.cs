

using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface ILeasingDataService
{
    Task<IEnumerable<LeasingData>> ListAsync();
    Task<IEnumerable<LeasingData>> ListByUserIdAsync(int userId);
    Task<LeasingData> FindByIdAsync(int id);
    Task<LeasingDataResponse> SaveAsync(LeasingData leasingData);
}