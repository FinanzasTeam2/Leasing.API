using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IVATService
{
    Task<IEnumerable<VAT>> ListAsync();
}