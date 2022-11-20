using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface ILeasingDataRepository
{
    Task<IEnumerable<LeasingData>> ListAsync();
    Task AddAsync(LeasingData leasingData);
    Task<LeasingData> FindByIdAsync(int id);
    Task<IEnumerable<LeasingData>>FindByUserIdAsync(int userId);
    Task<LeasingData> GetLastLeasingDataId();

}