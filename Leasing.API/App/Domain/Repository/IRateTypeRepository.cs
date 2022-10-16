using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface IRateTypeRepository
{
    Task<IEnumerable<RateType>> ListAsync();
    Task AddAsync(RateType rateType);
    Task<RateType> FindByIdAsync(int id);
    void Update(RateType rateType);
    void Remove(RateType rateType);
}