using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface ITimeService
{
    Task<IEnumerable<Time>> ListAsync();
}