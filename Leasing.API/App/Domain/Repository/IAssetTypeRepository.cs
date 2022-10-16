using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface IAssetTypeRepository
{
    Task<IEnumerable<AssetType>> ListAsync();
    Task AddAsync(AssetType assetType);
    Task<AssetType> FindByIdAsync(int id);
    void Update(AssetType assetType);
    void Remove(AssetType assetType);
}