using System.ComponentModel.DataAnnotations;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;

namespace Leasing.API.App.Domain.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindByIdAsync(int id);
    Task<User> FindByEmailAndPasswordAsync(string email,string password);
    Task AddAsync(User user);
    void Update(User user);
    void Remove(User user);
}