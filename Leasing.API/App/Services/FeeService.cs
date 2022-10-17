using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class FeeService:IFeeService
{
    private readonly IFeeRepository _FeeRepository;

    private readonly IUnitOfWork _unitOfWork;
    public FeeService(IFeeRepository FeeRepository, IUnitOfWork unitOfWork)
    {
        _FeeRepository = FeeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Fee>> ListAsync()
    {
        return await _FeeRepository.ListAsync();
    }
    
    public async Task<FeeResponse> SaveAsync(Fee Fee)
    {
        try
        {
            await _FeeRepository.AddAsync(Fee);
            await _unitOfWork.CompleteAsync();

            return new FeeResponse(Fee);
        }
        catch (Exception e)
        {
            return new FeeResponse($"An error occurred while saving the Fee: {e.Message}");
        }
    }

    public async Task<FeeResponse> UpdateAsync(int id, Fee Fee)
    {
        var existingFee = await _FeeRepository.FindByIdAsync(id);

        if (existingFee == null)
            return new FeeResponse("Fee not found.");

        existingFee.Quantity= Fee.Quantity;

        try
        {
            _FeeRepository.Update(existingFee);
            await _unitOfWork.CompleteAsync();
            
            return new FeeResponse(existingFee);
        }
        catch (Exception e)
        {
            return new FeeResponse($"An error occurred while updating the Fee: {e.Message}");
        }
    }

    public async Task<FeeResponse> DeleteAsync(int id)
    {
        var existingFee = await _FeeRepository.FindByIdAsync(id);

        if (existingFee == null)
            return new FeeResponse("Fee not found.");

        try
        {
            _FeeRepository.Remove(existingFee);
            await _unitOfWork.CompleteAsync();

            return new FeeResponse(existingFee);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new FeeResponse($"An error occurred while deleting the Fee: {e.Message}");
        }
    }
}