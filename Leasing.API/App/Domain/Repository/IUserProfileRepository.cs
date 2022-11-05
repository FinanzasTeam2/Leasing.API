using System.ComponentModel.DataAnnotations;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;

namespace Leasing.API.App.Domain.Repository;

public interface IUserProfileRepository
{
    Task<IEnumerable<UserProfile>> ListAsync();
    Task<UserProfile> FindByIdAsync(int id);
    Task<UserProfile> FindByEmailAndPasswordAsync(string email,string password);
    Task AddAsync(UserProfile userProfile);
    void Update(UserProfile userProfile);
    void Remove(UserProfile userProfile);
}