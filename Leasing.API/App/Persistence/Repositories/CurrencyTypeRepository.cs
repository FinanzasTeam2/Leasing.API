﻿using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Persistence.Repositories
{
public class CurrencyTypeRepository : BaseRepository, ICurrencyTypeRepository
{
    public CurrencyTypeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CurrencyType>> ListAsync()
    {
            return await _context.CurrencyTypes.ToListAsync();
    }

    public async Task AddAsync(CurrencyType currencyType)
    {
        await _context.CurrencyTypes.AddAsync(currencyType);
    }

    public async Task<CurrencyType> FindByIdAsync(int id)
    {
        return await _context.CurrencyTypes.FindAsync(id);
    }

    public void Update(CurrencyType currencyType)
    {
        _context.CurrencyTypes.Update(currencyType);
    }

    public void Remove(CurrencyType currencyType)
    {
        _context.CurrencyTypes.Remove(currencyType);
    }
}
}