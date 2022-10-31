using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface IVATRepository
{
    Task<IEnumerable<VAT>> ListAsync();
    Task<VAT> FindByIdAsync(int id);
}