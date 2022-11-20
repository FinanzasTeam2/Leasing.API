using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface ILeasingMethodRepository
{
    Task<IEnumerable<LeasingMethod>> ListAsync();
    Task<LeasingMethod> FindByIdAsync(int id);
}