using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class UserProfileService:IUserProfileService
{
    private readonly IUserProfileRepository _UserProfileRepository;

    private readonly IUnitOfWork _unitOfWork;
    public UserProfileService(IUserProfileRepository UserProfileRepository, IUnitOfWork unitOfWork)
    {
        _UserProfileRepository = UserProfileRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<UserProfile>> ListAsync()
    {
        return await _UserProfileRepository.ListAsync();
    }
    
    public async Task<UserProfileResponse> SaveAsync(UserProfile UserProfile)
    {
        try
        {
            await _UserProfileRepository.AddAsync(UserProfile);
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
        var existingUserProfile = await _UserProfileRepository.FindByIdAsync(id);

        if (existingUserProfile == null)
            return new UserProfileResponse("UserProfile not found.");

        existingUserProfile.UserId = UserProfile.UserId;
        existingUserProfile.FirstName = UserProfile.FirstName;
        existingUserProfile.LastName = UserProfile.LastName;

        try
        {
            _UserProfileRepository.Update(existingUserProfile);
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
        var existingUserProfile = await _UserProfileRepository.FindByIdAsync(id);

        if (existingUserProfile == null)
            return new UserProfileResponse("UserProfile not found.");

        try
        {
            _UserProfileRepository.Remove(existingUserProfile);
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