using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface ISolutionRepository
{
    Task<IEnumerable<Solution>> ListAsync();
    Task AddAsync(Solution solution);
    Task<Solution> FindByIdAsync(int id);
    void Update(Solution solution);
    void Remove(Solution solution);
    Task<IEnumerable<Solution>>FindByUserProfileIdAsync(int userprofileId);
}