using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _userRepository.FindByIdAsync(id);
    }

    public async Task<UserResponse> FindByEmailAndPasswordAsync(string email, string password)
    {
        var existingUser = await _userRepository.FindByEmailAndPasswordAsync(email,password);

        try
        {
            await _unitOfWork.CompleteAsync();

            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while detecting the User: {e.Message}");
        }
    }


    public async Task<UserResponse> SaveAsync(User User)
    {
        try
        {
            await _userRepository.AddAsync(User);
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
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found.");
        
        existingUser.Nombre = User.Nombre;
        existingUser.Apellido = User.Apellido;
        existingUser.Correo = User.Correo;
        existingUser.Contrasenia = User.Contrasenia;
        
        try
        {
            _userRepository.Update(existingUser);
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
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found.");

        try
        {
            _userRepository.Remove(existingUser);
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