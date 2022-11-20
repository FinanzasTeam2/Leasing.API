using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class LeasingResultService:ILeasingResultService
{
    private readonly ILeasingResultRepository _leasingResultRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly ILeasingDataRepository _leasingDataRepository;
    
    public LeasingResultService(ILeasingResultRepository leasingResultRepository, IUnitOfWork unitOfWork, ILeasingDataRepository leasingDataRepository)
    {
        _leasingResultRepository = leasingResultRepository;
        _unitOfWork = unitOfWork;
        _leasingDataRepository = leasingDataRepository;
    }
    
    public async Task<IEnumerable<LeasingResult>> ListAsync()
    {
        return await _leasingResultRepository.ListAsync();
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
        //Validate LeasingData Id
        var existingLeasingData =  _leasingDataRepository.GetLastLeasingDataId();
        
        if (existingLeasingData == null)
            return new LeasingResultResponse("Invalid LeasingData");

        leasingResult.LeasingDataId = existingLeasingData.Id;
        
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