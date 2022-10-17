using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class FeeTypeService:IFeeTypeService
{
    private readonly IFeeTypeRepository _FeeTypeRepository;

    private readonly IUnitOfWork _unitOfWork;
    public FeeTypeService(IFeeTypeRepository FeeTypeRepository, IUnitOfWork unitOfWork)
    {
        _FeeTypeRepository = FeeTypeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<FeeType>> ListAsync()
    {
        return await _FeeTypeRepository.ListAsync();
    }
    
    public async Task<FeeTypeResponse> SaveAsync(FeeType FeeType)
    {
        try
        {
            await _FeeTypeRepository.AddAsync(FeeType);
            await _unitOfWork.CompleteAsync();

            return new FeeTypeResponse(FeeType);
        }
        catch (Exception e)
        {
            return new FeeTypeResponse($"An error occurred while saving the FeeType: {e.Message}");
        }
    }

    public async Task<FeeTypeResponse> UpdateAsync(int id, FeeType FeeType)
    {
        var existingFeeType = await _FeeTypeRepository.FindByIdAsync(id);

        if (existingFeeType == null)
            return new FeeTypeResponse("FeeType not found.");

        existingFeeType.FeeName = FeeType.FeeName;

        try
        {
            _FeeTypeRepository.Update(existingFeeType);
            await _unitOfWork.CompleteAsync();
            
            return new FeeTypeResponse(existingFeeType);
        }
        catch (Exception e)
        {
            return new FeeTypeResponse($"An error occurred while updating the FeeType: {e.Message}");
        }
    }

    public async Task<FeeTypeResponse> DeleteAsync(int id)
    {
        var existingFeeType = await _FeeTypeRepository.FindByIdAsync(id);

        if (existingFeeType == null)
            return new FeeTypeResponse("FeeType not found.");

        try
        {
            _FeeTypeRepository.Remove(existingFeeType);
            await _unitOfWork.CompleteAsync();

            return new FeeTypeResponse(existingFeeType);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new FeeTypeResponse($"An error occurred while deleting the FeeType: {e.Message}");
        }
    }
}