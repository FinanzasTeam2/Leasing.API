using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class ProfileUserResponse:BaseResponse<UserProfile>
{
    public ProfileUserResponse(UserProfile resource) : base(resource)
    {
    }

    public ProfileUserResponse(string message) : base(message)
    {
    }
}