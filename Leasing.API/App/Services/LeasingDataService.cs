using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class LeasingDataService:ILeasingDataService
{
    private readonly ILeasingDataRepository _leasingDataRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IUserRepository _userRepository;
    public LeasingDataService(ILeasingDataRepository leasingDataRepository, IUnitOfWork unitOfWork)
    {
        _leasingDataRepository = leasingDataRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<LeasingData>> ListAsync()
    {
        return await _leasingDataRepository.ListAsync();
    }
    
    public async Task<IEnumerable<LeasingData>> ListByUserIdAsync(int userId)
    {
        return await _leasingDataRepository.FindByUserIdAsync(userId);
    }
    
    public async Task<LeasingData> FindByIdAsync(int id)
    {
        return await _leasingDataRepository.FindByIdAsync(id);
    }
    
    public async Task<LeasingDataResponse> SaveAsync(LeasingData leasingData)
    {
        //Validate UserProfile Id
        //var existingUser = _userRepository.FindByIdAsync(leasingData.UserId);

        //if (existingUser == null)
        //   return new LeasingDataResponse("Invalid User");
        
        try
        {
            await _leasingDataRepository.AddAsync(leasingData);
            await _unitOfWork.CompleteAsync();

            return new LeasingDataResponse(leasingData);
        }
        catch (Exception e)
        {
            return new LeasingDataResponse($"An error occurred while saving the LeasingData: {e.Message}");
        }
    }
}