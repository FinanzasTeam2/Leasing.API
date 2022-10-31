using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories;

public class VATRepository:BaseRepository,IVATRepository
{
    public VATRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<VAT>> ListAsync()
    {
        return await _context.VATs.ToListAsync();
    }

    public async Task<VAT> FindByIdAsync(int id)
    {
        return await _context.VATs.FindAsync(id);
    }
}