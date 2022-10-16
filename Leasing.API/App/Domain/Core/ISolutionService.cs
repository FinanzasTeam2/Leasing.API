using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface ISolutionService
{
    Task<IEnumerable<Solution>> ListAsync();
    Task<SolutionResponse> SaveAsync(Solution solution);
    Task<SolutionResponse> UpdateAsync(int id, Solution solution);
    Task<SolutionResponse> DeleteAsync(int id);
}