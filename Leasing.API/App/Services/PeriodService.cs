using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class PeriodService:IPeriodService
{
    private readonly IPeriodRepository _PeriodRepository;

    private readonly IUnitOfWork _unitOfWork;
    public PeriodService(IPeriodRepository PeriodRepository, IUnitOfWork unitOfWork)
    {
        _PeriodRepository = PeriodRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Period>> ListAsync()
    {
        return await _PeriodRepository.ListAsync();
    }
    
    public async Task<PeriodResponse> SaveAsync(Period Period)
    {
        try
        {
            await _PeriodRepository.AddAsync(Period);
            await _unitOfWork.CompleteAsync();

            return new PeriodResponse(Period);
        }
        catch (Exception e)
        {
            return new PeriodResponse($"An error occurred while saving the Period: {e.Message}");
        }
    }

    public async Task<PeriodResponse> UpdateAsync(int id, Period Period)
    {
        var existingPeriod = await _PeriodRepository.FindByIdAsync(id);

        if (existingPeriod == null)
            return new PeriodResponse("Period not found.");

        existingPeriod.Quantity = Period.Quantity;

        try
        {
            _PeriodRepository.Update(existingPeriod);
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
        var existingPeriod = await _PeriodRepository.FindByIdAsync(id);

        if (existingPeriod == null)
            return new PeriodResponse("Period not found.");

        try
        {
            _PeriodRepository.Remove(existingPeriod);
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