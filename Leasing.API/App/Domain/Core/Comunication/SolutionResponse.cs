using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class SolutionResponse:BaseResponse<Solution>
{
    public SolutionResponse(Solution resource) : base(resource)
    {
    }

    public SolutionResponse(string message) : base(message)
    {
    }
}