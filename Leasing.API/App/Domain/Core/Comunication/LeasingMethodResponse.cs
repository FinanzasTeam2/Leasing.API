using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class LeasingMethodResponse:BaseResponse<LeasingMethod>
{
    public LeasingMethodResponse(LeasingMethod resource) : base(resource)
    {
    }

    public LeasingMethodResponse(string message) : base(message)
    {
    }
}
