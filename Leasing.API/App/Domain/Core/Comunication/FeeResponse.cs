using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class FeeResponse:BaseResponse<Fee>
{
    public FeeResponse(Fee resource) : base(resource)
    {
    }

    public FeeResponse(string message) : base(message)
    {
    }
}
