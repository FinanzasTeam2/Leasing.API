using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IProfileUserService
{
    Task<IEnumerable<ProfileUser>> ListAsync();
    Task<ProfileUserResponse> SaveAsync(ProfileUser profileUser);
    Task<ProfileUserResponse> UpdateAsync(int id, ProfileUser profileUser);
    Task<ProfileUserResponse> DeleteAsync(int id);
}