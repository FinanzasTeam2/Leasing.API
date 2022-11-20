using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class CurrencyTypeService:ICurrencyTypeService
{
    private readonly ICurrencyTypeRepository _currencyTypeRepository;

    private readonly IUnitOfWork _unitOfWork;
    
    public CurrencyTypeService(ICurrencyTypeRepository currencyTypeRepository, IUnitOfWork unitOfWork)
    {
        _currencyTypeRepository = currencyTypeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<CurrencyType>> ListAsync()
    {
        return await _currencyTypeRepository.ListAsync();
    }
    
    public async Task<CurrencyType> FindByIdAsync(int id)
    {
        return await _currencyTypeRepository.FindByIdAsync(id);
    }
}