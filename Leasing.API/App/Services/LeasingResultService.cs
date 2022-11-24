using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class LeasingResultService:ILeasingResultService
{
    private readonly ILeasingResultRepository _leasingResultRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly ILeasingDataRepository _leasingDataRepository;
    
    public LeasingResultService(ILeasingResultRepository leasingResultRepository, IUnitOfWork unitOfWork, ILeasingDataRepository leasingDataRepository, IUserRepository userRepository)
    {
        _leasingResultRepository = leasingResultRepository;
        _unitOfWork = unitOfWork;
        _leasingDataRepository = leasingDataRepository;
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<LeasingResult>> ListAsync()
    {
        return await _leasingResultRepository.ListAsync();
    }

    public async Task<IEnumerable<LeasingResult>> FindByUserIdAsync(int userId)
    {
        var isExist = await _userRepository.FindByIdAsync(userId);
        if (isExist == null)
        {
            return null;
        }
        return await _leasingResultRepository.FindByUserIdAsync(userId);
    }

    public async Task<IEnumerable<LeasingResult>> FindByLeasingDataIdAsync(int userId)
    {
        return await _leasingResultRepository.FindByLeasingDataIdAsync(userId);
    }
    
    public async Task<LeasingResult> FindByIdAsync(int id)
    {
        return await _leasingResultRepository.FindByIdAsync(id);
    }
    
    public async Task<LeasingResultResponse> SaveAsync(LeasingResult leasingResult)
    {
        var isExist = await _leasingDataRepository.FindByIdAsync(leasingResult.LeasingDataId);
        if (isExist == null)
        {
            return new LeasingResultResponse("Leasing data not found");
        }
        leasingResult.LeasingData = isExist;
        
        try
        {
            await _leasingResultRepository.AddAsync(leasingResult);
            await _unitOfWork.CompleteAsync();

            return new LeasingResultResponse(leasingResult);
        }
        catch (Exception e)
        {
            return new LeasingResultResponse($"An error occurred while saving the LeasingResult: {e.Message}");
        }
    }
}