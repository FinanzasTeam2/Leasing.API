using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface ILeasingMethodService
{
    Task<IEnumerable<LeasingMethod>> ListAsync();
    Task<LeasingMethod> FindByIdAsync(int id);
}