using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class FeeResponse:BaseResponse<FeeResponse>
{
    public FeeResponse(FeeResponse resource) : base(resource)
    {
    }

    public FeeResponse(string message) : base(message)
    {
    }
}