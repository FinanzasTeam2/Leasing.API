using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface ILeasingResultService
{
    Task<IEnumerable<LeasingResult>> ListAsync();
    Task<LeasingResultResponse> SaveAsync(LeasingResult leasingData);
}