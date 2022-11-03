using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class PeriodService:IPeriodService
{
    private readonly IPeriodRepository _periodRepository;

    private readonly IUnitOfWork _unitOfWork;
    public PeriodService(IPeriodRepository periodRepository, IUnitOfWork unitOfWork)
    {
        _periodRepository = periodRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Period>> ListAsync()
    {
        return await _periodRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Period>> ListByTimeIdAsync(int timeId)
    {
        return await _periodRepository.FindByTimeIdAsync(timeId);
    }
    
    public async Task<PeriodResponse> SaveAsync(Period period)
    {
        try
        {
            await _periodRepository.AddAsync(period);
            await _unitOfWork.CompleteAsync();

            return new PeriodResponse(period);
        }
        catch (Exception e)
        {
            return new PeriodResponse($"An error occurred while saving the Period: {e.Message}");
        }
    }

    public async Task<PeriodResponse> UpdateAsync(int id, Period period)
    {
        var existingPeriod = await _periodRepository.FindByIdAsync(id);

        if (existingPeriod == null)
            return new PeriodResponse("Period not found.");

        existingPeriod.Quantity = period.Quantity;
        existingPeriod.TimeId = period.TimeId;

        try
        {
            _periodRepository.Update(existingPeriod);
            await _unitOfWork.CompleteAsync();
            
            return new PeriodResponse(existingPeriod);
        }
        catch (Exception e)
        {
            return new PeriodResponse($"An error occurred while updating the Period: {e.Message}");
        }
    }

    public async Task<PeriodResponse> DeleteAsync(int id)
    {
        var existingPeriod = await _periodRepository.FindByIdAsync(id);

        if (existingPeriod == null)
            return new PeriodResponse("Period not found.");

        try
        {
            _periodRepository.Remove(existingPeriod);
            await _unitOfWork.CompleteAsync();

            return new PeriodResponse(existingPeriod);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new PeriodResponse($"An error occurred while deleting the Period: {e.Message}");
        }
    }
}