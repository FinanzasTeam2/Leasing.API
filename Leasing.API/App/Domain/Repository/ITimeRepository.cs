using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface ITimeRepository
{
    Task<IEnumerable<Time>> ListAsync();
    Task<Time> FindByIdAsync(int id);

}