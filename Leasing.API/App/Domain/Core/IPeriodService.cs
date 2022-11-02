using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IPeriodService
{
    Task<IEnumerable<Period>> ListAsync();
    Task<PeriodResponse> SaveAsync(Period period);
    Task<PeriodResponse> UpdateAsync(int id, Period period);
    Task<PeriodResponse> DeleteAsync(int id);
    Task<IEnumerable<Period>> ListByTimeIdAsync(int timeId);
}