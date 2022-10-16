using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Core;

public interface IAssetTypeService
{
    Task<IEnumerable<AssetType>> ListAsync();
    Task<AssetTypeResponse> SaveAsync(AssetType assetType);
    Task<AssetTypeResponse> UpdateAsync(int id, AssetType assetType);
    Task<AssetTypeResponse> DeleteAsync(int id);
}