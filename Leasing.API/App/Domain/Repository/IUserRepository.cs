using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    void Update(User user);
    void Remove(User user);
}