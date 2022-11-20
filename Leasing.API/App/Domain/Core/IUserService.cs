using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindByIdAsync(int id);
    Task<UserResponse> FindByEmailAndPasswordAsync(string email, string password);
    Task<UserResponse> SaveAsync(User profileUser);
    Task<UserResponse> UpdateAsync(int id, User profileUser);
    Task<UserResponse> DeleteAsync(int id);
}