using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface IPeriodRepository
{
    Task<IEnumerable<Period>> ListAsync();
    Task AddAsync(Period period);
    Task<Period> FindByIdAsync(int id);
    void Update(Period period);
    void Remove(Period period);
}