using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class SolutionService:ISolutionService
{
    private readonly ISolutionRepository _SolutionRepository;

    private readonly IUnitOfWork _unitOfWork;
    public SolutionService(ISolutionRepository SolutionRepository, IUnitOfWork unitOfWork)
    {
        _SolutionRepository = SolutionRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Solution>> ListAsync()
    {
        return await _SolutionRepository.ListAsync();
    }
    
    public async Task<SolutionResponse> SaveAsync(Solution Solution)
    {
        try
        {
            await _SolutionRepository.AddAsync(Solution);
            await _unitOfWork.CompleteAsync();

            return new SolutionResponse(Solution);
        }
        catch (Exception e)
        {
            return new SolutionResponse($"An error occurred while saving the Solution: {e.Message}");
        }
    }

    public async Task<SolutionResponse> UpdateAsync(int id, Solution Solution)
    {
        var existingSolution = await _SolutionRepository.FindByIdAsync(id);

        if (existingSolution == null)
            return new SolutionResponse("Solution not found.");

        existingSolution.Value = Solution.Value;
        existingSolution.LoanDate = Solution.LoanDate;

        try
        {
            _SolutionRepository.Update(existingSolution);
            await _unitOfWork.CompleteAsync();
            
            return new SolutionResponse(existingSolution);
        }
        catch (Exception e)
        {
            return new SolutionResponse($"An error occurred while updating the Solution: {e.Message}");
        }
    }

    public async Task<SolutionResponse> DeleteAsync(int id)
    {
        var existingSolution = await _SolutionRepository.FindByIdAsync(id);

        if (existingSolution == null)
            return new SolutionResponse("Solution not found.");

        try
        {
            _SolutionRepository.Remove(existingSolution);
            await _unitOfWork.CompleteAsync();

            return new SolutionResponse(existingSolution);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new SolutionResponse($"An error occurred while deleting the Solution: {e.Message}");
        }
    }
}