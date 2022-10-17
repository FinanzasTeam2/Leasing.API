using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class CurrencyTypeService:ICurrencyTypeService
{
    private readonly ICurrencyTypeRepository _CurrencyTypeRepository;

    private readonly IUnitOfWork _unitOfWork;
    public CurrencyTypeService(ICurrencyTypeRepository CurrencyTypeRepository, IUnitOfWork unitOfWork)
    {
        _CurrencyTypeRepository = CurrencyTypeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<CurrencyType>> ListAsync()
    {
        return await _CurrencyTypeRepository.ListAsync();
    }
    
    public async Task<CurrencyTypeResponse> SaveAsync(CurrencyType CurrencyType)
    {
        try
        {
            await _CurrencyTypeRepository.AddAsync(CurrencyType);
            await _unitOfWork.CompleteAsync();

            return new CurrencyTypeResponse(CurrencyType);
        }
        catch (Exception e)
        {
            return new CurrencyTypeResponse($"An error occurred while saving the CurrencyType: {e.Message}");
        }
    }

    public async Task<CurrencyTypeResponse> UpdateAsync(int id, CurrencyType CurrencyType)
    {
        var existingCurrencyType = await _CurrencyTypeRepository.FindByIdAsync(id);

        if (existingCurrencyType == null)
            return new CurrencyTypeResponse("CurrencyType not found.");

        existingCurrencyType.Price = CurrencyType.Price;
        existingCurrencyType.CurrencyName = CurrencyType.CurrencyName;
        
        try
        {
            _CurrencyTypeRepository.Update(existingCurrencyType);
            await _unitOfWork.CompleteAsync();
            
            return new CurrencyTypeResponse(existingCurrencyType);
        }
        catch (Exception e)
        {
            return new CurrencyTypeResponse($"An error occurred while updating the CurrencyType: {e.Message}");
        }
    }

    public async Task<CurrencyTypeResponse> DeleteAsync(int id)
    {
        var existingCurrencyType = await _CurrencyTypeRepository.FindByIdAsync(id);

        if (existingCurrencyType == null)
            return new CurrencyTypeResponse("CurrencyType not found.");

        try
        {
            _CurrencyTypeRepository.Remove(existingCurrencyType);
            await _unitOfWork.CompleteAsync();

            return new CurrencyTypeResponse(existingCurrencyType);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CurrencyTypeResponse($"An error occurred while deleting the CurrencyType: {e.Message}");
        }
    }
}