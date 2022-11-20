using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class LeasingResultResponse:BaseResponse<LeasingResult>
{
    public LeasingResultResponse(LeasingResult resource) : base(resource)
    {
    }

    public LeasingResultResponse(string message) : base(message)
    {
    }
}