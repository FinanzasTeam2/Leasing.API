using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.Shared.Domain.Repositories;

namespace Leasing.API.App.Services;

public class SolutionService:ISolutionService
{
    private readonly ISolutionRepository _solutionRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IRateTypeRepository _rateTypeRepository;
    private readonly IFeeRepository _feeRepository;
    private readonly IAssetTypeRepository _assetTypeRepository;
    private readonly IVATRepository _vatRepository;
    private readonly IPeriodRepository _periodRepository;
    private readonly ICurrencyTypeRepository _currencyTypeRepository;
    public SolutionService(ISolutionRepository solutionRepository, IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository,IRateTypeRepository rateTypeRepository,
        IFeeRepository feeRepository,IAssetTypeRepository assetTypeRepository,IVATRepository vatRepository,IPeriodRepository periodRepository,
        ICurrencyTypeRepository currencyTypeRepository)
    {
        _solutionRepository = solutionRepository;
        _unitOfWork = unitOfWork;
        _userProfileRepository=userProfileRepository; 
        _rateTypeRepository   =rateTypeRepository;
        _feeRepository=feeRepository;
        _assetTypeRepository=assetTypeRepository;
        _vatRepository=vatRepository;
        _periodRepository=periodRepository;
        _currencyTypeRepository=currencyTypeRepository;
    }
    
    public async Task<IEnumerable<Solution>> ListAsync()
    {
        return await _solutionRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Solution>> ListByUserProfileIdAsync(int userprofileId)
    {
        return await _solutionRepository.FindByUserProfileIdAsync(userprofileId);
    }
    
    public async Task<SolutionResponse> SaveAsync(Solution solution)
    {
        //Validate UserProfile Id
        var existingUserProfile = _userProfileRepository.FindByIdAsync(solution.UserProfileId);

        if (existingUserProfile == null)
            return new SolutionResponse("Invalid Category");

        try
        {
            await _solutionRepository.AddAsync(solution);
            await _unitOfWork.CompleteAsync();

            return new SolutionResponse(solution);
        }
        catch (Exception e)
        {
            return new SolutionResponse($"An error occurred while saving the Solution: {e.Message}");
        }
    }

    public async Task<SolutionResponse> UpdateAsync(int id, Solution Solution)
    {
        var existingSolution = await _solutionRepository.FindByIdAsync(id);

        if (existingSolution == null)
            return new SolutionResponse("Solution not found.");

        existingSolution.Value = Solution.Value;
        existingSolution.LoanDate = Solution.LoanDate;

        try
        {
            _solutionRepository.Update(existingSolution);
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
        var existingSolution = await _solutionRepository.FindByIdAsync(id);

        if (existingSolution == null)
            return new SolutionResponse("Solution not found.");

        try
        {
            _solutionRepository.Remove(existingSolution);
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