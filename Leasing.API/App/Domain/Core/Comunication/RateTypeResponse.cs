using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class RateTypeResponse:BaseResponse<RateType>
{
    public RateTypeResponse(RateType resource) : base(resource)
    {
    }

    public RateTypeResponse(string message) : base(message)
    {
    }
}