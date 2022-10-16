using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class PeriodResponse:BaseResponse<Period>
{
    public PeriodResponse(Period resource) : base(resource)
    {
    }

    public PeriodResponse(string message) : base(message)
    {
    }
}