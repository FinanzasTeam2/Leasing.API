using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class TimeService:ITimeService
{
    private readonly ITimeRepository _TimeRepository;

    private readonly IUnitOfWork _unitOfWork;
    
    public TimeService(ITimeRepository TimeRepository, IUnitOfWork unitOfWork)
    {
        _TimeRepository = TimeRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<IEnumerable<Time>> ListAsync()
    {
        return await _TimeRepository.ListAsync();
    }
    
}