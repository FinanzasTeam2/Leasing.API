using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);
}