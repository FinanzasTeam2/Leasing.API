using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class FeeTypeResponse:BaseResponse<FeeType>
{
    public FeeTypeResponse(FeeType resource) : base(resource)
    {
    }

    public FeeTypeResponse(string message) : base(message)
    {
    }
}