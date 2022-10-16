using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface IUserProfileRepository
{
    Task<IEnumerable<UserProfile>> ListAsync();
    Task AddAsync(UserProfile userProfile);
    Task<UserProfile> FindByIdAsync(int id);
    void Update(UserProfile userProfile);
    void Remove(UserProfile userProfile);
}