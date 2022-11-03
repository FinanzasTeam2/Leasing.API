using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Leasing.API.App.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasing.API.App.Controllers.OneToMany;

[ApiController]
[Route("/api/v1/userprofiles/{userprofileId}/solutions")]
public class UserProfileSolutionsController
{
    private readonly ISolutionService _solutionService;
    private readonly IMapper _mapper;

    public UserProfileSolutionsController(ISolutionService solutionService, IMapper mapper)
    {
        _solutionService = solutionService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Solutions for given UserProfile",
        Description = "Get existing Solutions associated with the specified UserProfile",
        OperationId = "GetUserProfileSolutions",
        Tags = new[] {"UserProfiles"})]
    public async Task<IEnumerable<SolutionResource>> GetAllByUserProfileIdAsync(int userprofileId)
    {
        var solutions = await _solutionService.ListByUserProfileIdAsync(userprofileId);
        var resources = _mapper.Map<IEnumerable<Solution>, IEnumerable<SolutionResource>>(solutions);
        return resources;
    }
}