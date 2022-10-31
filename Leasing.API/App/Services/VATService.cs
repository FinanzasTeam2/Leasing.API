using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class VATService:IVATService
{
    private readonly IVATRepository _VATRepository;

    private readonly IUnitOfWork _unitOfWork;
    
    public VATService(IVATRepository VATRepository, IUnitOfWork unitOfWork)
    {
        _VATRepository = VATRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<VAT>> ListAsync()
    {
        return await _VATRepository.ListAsync();
    }
}