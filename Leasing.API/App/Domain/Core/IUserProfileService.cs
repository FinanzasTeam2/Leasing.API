using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfile>> ListAsync();
    Task<ProfileUserResponse> SaveAsync(UserProfile profileUser);
    Task<ProfileUserResponse> UpdateAsync(int id, UserProfile profileUser);
    Task<ProfileUserResponse> DeleteAsync(int id);
}