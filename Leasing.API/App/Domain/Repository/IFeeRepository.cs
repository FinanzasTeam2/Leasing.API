using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface IFeeRepository
{
    Task<IEnumerable<Fee>> ListAsync();
    Task AddAsync(Fee fee);
    Task<Fee> FindByIdAsync(int id);
    void Update(Fee fee);
    void Remove(Fee fee);
}