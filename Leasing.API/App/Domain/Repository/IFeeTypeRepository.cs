using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface IFeeTypeRepository
{
    Task<IEnumerable<FeeType>> ListAsync();
    Task AddAsync(FeeType feeType);
    Task<FeeType> FindByIdAsync(int id);
    void Update(FeeType feeType);
    void Remove(FeeType feeType);
}