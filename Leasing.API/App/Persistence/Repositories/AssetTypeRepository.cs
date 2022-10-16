using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;

namespace Leasing.API.App.Persistence.Repositories;

public class AssetTypeRepository:BaseRepository,IAssetTypeRepository
{
    public AssetTypeRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<AssetType>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(AssetType assetType)
    {
        throw new NotImplementedException();
    }

    public Task<AssetType> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(AssetType assetType)
    {
        throw new NotImplementedException();
    }

    public void Remove(AssetType assetType)
    {
        throw new NotImplementedException();
    }
}