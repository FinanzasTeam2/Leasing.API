using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class AssetTypeService:IAssetTypeService
{
    private readonly IAssetTypeRepository _AssetTypeRepository;

    private readonly IUnitOfWork _unitOfWork;
    public AssetTypeService(IAssetTypeRepository AssetTypeRepository, IUnitOfWork unitOfWork)
    {
        _AssetTypeRepository = AssetTypeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<AssetType>> ListAsync()
    {
        return await _AssetTypeRepository.ListAsync();
    }
    
    public async Task<AssetTypeResponse> SaveAsync(AssetType AssetType)
    {
        try
        {
            await _AssetTypeRepository.AddAsync(AssetType);
            await _unitOfWork.CompleteAsync();

            return new AssetTypeResponse(AssetType);
        }
        catch (Exception e)
        {
            return new AssetTypeResponse($"An error occurred while saving the AssetType: {e.Message}");
        }
    }

    public async Task<AssetTypeResponse> UpdateAsync(int id, AssetType AssetType)
    {
        var existingAssetType = await _AssetTypeRepository.FindByIdAsync(id);

        if (existingAssetType == null)
            return new AssetTypeResponse("AssetType not found.");

        existingAssetType.Name = AssetType.Name;

        try
        {
            _AssetTypeRepository.Update(existingAssetType);
            await _unitOfWork.CompleteAsync();
            
            return new AssetTypeResponse(existingAssetType);
        }
        catch (Exception e)
        {
            return new AssetTypeResponse($"An error occurred while updating the AssetType: {e.Message}");
        }
    }

    public async Task<AssetTypeResponse> DeleteAsync(int id)
    {
        var existingAssetType = await _AssetTypeRepository.FindByIdAsync(id);

        if (existingAssetType == null)
            return new AssetTypeResponse("AssetType not found.");

        try
        {
            _AssetTypeRepository.Remove(existingAssetType);
            await _unitOfWork.CompleteAsync();

            return new AssetTypeResponse(existingAssetType);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new AssetTypeResponse($"An error occurred while deleting the AssetType: {e.Message}");
        }
    }
}