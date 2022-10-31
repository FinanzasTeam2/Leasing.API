using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class TimeResponse:BaseResponse<Time>
{
    public TimeResponse(Time resource) : base(resource)
    {
    }

    public TimeResponse(string message) : base(message)
    {
    }
}