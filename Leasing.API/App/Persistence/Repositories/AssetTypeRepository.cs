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
        return await _context.AssetType.ToListAsync();
    }

    public Task AddAsync(AssetType assetType)
    {
        await _context.AssetType.AddAsync(assetType);
    }

    public Task<AssetType> FindByIdAsync(int id)
    {
        return await _context.AssetType.FindAsync(id);
    }

    public void Update(AssetType assetType)
    {
        _context.AssetType.Update(assetType);
    }

    public void Remove(AssetType assetType)
    {
        _context.AssetType.Remove(assetType);
    }
}