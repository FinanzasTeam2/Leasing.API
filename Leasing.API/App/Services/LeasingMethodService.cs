using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class LeasingMethodService:ILeasingMethodService
{
    private readonly ILeasingMethodRepository _leasingMethodRepository;

    private readonly IUnitOfWork _unitOfWork;
    
    public LeasingMethodService(ILeasingMethodRepository leasingMethodRepository, IUnitOfWork unitOfWork)
    {
        _leasingMethodRepository = leasingMethodRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<LeasingMethod>> ListAsync()
    {
        return await _leasingMethodRepository.ListAsync();
    }
    
    public async Task<LeasingMethod> FindByIdAsync(int id)
    {
        return await _leasingMethodRepository.FindByIdAsync(id);
    }
}