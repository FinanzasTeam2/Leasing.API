using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{

    public class AssetTypeRepository : BaseRepository, IAssetTypeRepository
    {
        public AssetTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AssetType>> ListAsync()
        {
            return await _context.AssetTypes.ToListAsync();
        }

        public async Task AddAsync(AssetType assetType)
        {
            await _context.AssetTypes.AddAsync(assetType);
        }

        public async Task<AssetType> FindByIdAsync(int id)
        {
            return await _context.AssetTypes.FindAsync(id);
        }

        public void Update(AssetType assetType)
        {
            _context.AssetTypes.Update(assetType);
        }

        public void Remove(AssetType assetType)
        {
            _context.AssetTypes.Remove(assetType);
        }
    }
}