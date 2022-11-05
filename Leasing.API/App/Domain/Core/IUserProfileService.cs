using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfile>> ListAsync();
    Task<UserProfile> FindByIdAsync(int id);
    Task<UserProfileResponse> FindByEmailAndPasswordAsync(string email, string password);
    Task<UserProfileResponse> SaveAsync(UserProfile profileUser);
    Task<UserProfileResponse> UpdateAsync(int id, UserProfile profileUser);
    Task<UserProfileResponse> DeleteAsync(int id);
}