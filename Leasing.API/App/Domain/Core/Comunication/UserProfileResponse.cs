using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class UserProfileResponse:BaseResponse<UserProfile>
{
    public UserProfileResponse(UserProfile resource) : base(resource)
    {
    }

    public UserProfileResponse(string message) : base(message)
    {
    }
}