using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class RateTypeService:IRateTypeService
{
    private readonly IRateTypeRepository _RateTypeRepository;

    private readonly IUnitOfWork _unitOfWork;
    public RateTypeService(IRateTypeRepository RateTypeRepository, IUnitOfWork unitOfWork)
    {
        _RateTypeRepository = RateTypeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<RateType>> ListAsync()
    {
        return await _RateTypeRepository.ListAsync();
    }
    
    public async Task<RateTypeResponse> SaveAsync(RateType RateType)
    {
        try
        {
            await _RateTypeRepository.AddAsync(RateType);
            await _unitOfWork.CompleteAsync();

            return new RateTypeResponse(RateType);
        }
        catch (Exception e)
        {
            return new RateTypeResponse($"An error occurred while saving the RateType: {e.Message}");
        }
    }

    public async Task<RateTypeResponse> UpdateAsync(int id, RateType RateType)
    {
        var existingRateType = await _RateTypeRepository.FindByIdAsync(id);

        if (existingRateType == null)
            return new RateTypeResponse("RateType not found.");

        existingRateType.Percentage = RateType.Percentage;
        existingRateType.RateName = RateType.RateName;

        try
        {
            _RateTypeRepository.Update(existingRateType);
            await _unitOfWork.CompleteAsync();
            
            return new RateTypeResponse(existingRateType);
        }
        catch (Exception e)
        {
            return new RateTypeResponse($"An error occurred while updating the RateType: {e.Message}");
        }
    }

    public async Task<RateTypeResponse> DeleteAsync(int id)
    {
        var existingRateType = await _RateTypeRepository.FindByIdAsync(id);

        if (existingRateType == null)
            return new RateTypeResponse("RateType not found.");

        try
        {
            _RateTypeRepository.Remove(existingRateType);
            await _unitOfWork.CompleteAsync();

            return new RateTypeResponse(existingRateType);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new RateTypeResponse($"An error occurred while deleting the RateType: {e.Message}");
        }
    }
}