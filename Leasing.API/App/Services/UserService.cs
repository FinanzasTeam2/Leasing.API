using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _UserRepository;

    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUserRepository UserRepository, IUnitOfWork unitOfWork)
    {
        _UserRepository = UserRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _UserRepository.ListAsync();
    }
    
    public async Task<UserResponse> SaveAsync(User User)
    {
        try
        {
            await _UserRepository.AddAsync(User);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(User);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while saving the User: {e.Message}");
        }
    }

    public async Task<UserResponse> UpdateAsync(int id, User User)
    {
        var existingUser = await _UserRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found.");

        existingUser.Email = User.Email;
        existingUser.Password= User.Password;

        try
        {
            _UserRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while updating the User: {e.Message}");
        }
    }

    public async Task<UserResponse> DeleteAsync(int id)
    {
        var existingUser = await _UserRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found.");

        try
        {
            _UserRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new UserResponse($"An error occurred while deleting the User: {e.Message}");
        }
    }
}