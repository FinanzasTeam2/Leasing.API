using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class UserProfileService:IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepository;

    private readonly IUnitOfWork _unitOfWork;
    public UserProfileService(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
    {
        _userProfileRepository = userProfileRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<UserProfile>> ListAsync()
    {
        return await _userProfileRepository.ListAsync();
    }

    public async Task<UserProfile> FindByIdAsync(int id)
    {
        return await _userProfileRepository.FindByIdAsync(id);
    }

    public async Task<UserProfileResponse> SaveAsync(UserProfile UserProfile)
    {
        try
        {
            await _userProfileRepository.AddAsync(UserProfile);
            await _unitOfWork.CompleteAsync();

            return new UserProfileResponse(UserProfile);
        }
        catch (Exception e)
        {
            return new UserProfileResponse($"An error occurred while saving the UserProfile: {e.Message}");
        }
    }

    public async Task<UserProfileResponse> UpdateAsync(int id, UserProfile UserProfile)
    {
        var existingUserProfile = await _userProfileRepository.FindByIdAsync(id);

        if (existingUserProfile == null)
            return new UserProfileResponse("UserProfile not found.");
        
        existingUserProfile.FirstName = UserProfile.FirstName;
        existingUserProfile.LastName = UserProfile.LastName;
        existingUserProfile.Email = UserProfile.Email;
        existingUserProfile.Password = UserProfile.Password;
        
        try
        {
            _userProfileRepository.Update(existingUserProfile);
            await _unitOfWork.CompleteAsync();
            
            return new UserProfileResponse(existingUserProfile);
        }
        catch (Exception e)
        {
            return new UserProfileResponse($"An error occurred while updating the UserProfile: {e.Message}");
        }
    }

    public async Task<UserProfileResponse> DeleteAsync(int id)
    {
        var existingUserProfile = await _userProfileRepository.FindByIdAsync(id);

        if (existingUserProfile == null)
            return new UserProfileResponse("UserProfile not found.");

        try
        {
            _userProfileRepository.Remove(existingUserProfile);
            await _unitOfWork.CompleteAsync();

            return new UserProfileResponse(existingUserProfile);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new UserProfileResponse($"An error occurred while deleting the UserProfile: {e.Message}");
        }
    }
}