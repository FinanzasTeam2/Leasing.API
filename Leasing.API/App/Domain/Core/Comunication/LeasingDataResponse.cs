using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class LeasingDataResponse:BaseResponse<LeasingData>
{
    public LeasingDataResponse(LeasingData resource) : base(resource)
    {
    }

    public LeasingDataResponse(string message) : base(message)
    {
    }
}