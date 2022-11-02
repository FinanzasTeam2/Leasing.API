using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Leasing.API.App.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasing.API.App.Controllers.OneToMany;

[ApiController]
[Route("/api/v1/users/{userId}/userprofiles")]
public class UserUserProfilesController
{
    private readonly IUserProfileService _userprofileService;
    private readonly IMapper _mapper;

    public UserUserProfilesController(IUserProfileService userprofileService, IMapper mapper)
    {
        _userprofileService = userprofileService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All UserProfiles for given User",
        Description = "Get existing UserProfiles associated with the specified User",
        OperationId = "GetUserUserProfile",
        Tags = new[] {"Users"})]
    public async Task<IEnumerable<UserProfileResource>> GetAllByUserIdAsync(int userId)
    {
        var userprofiles = await _userprofileService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(userprofiles);
        return resources;
    }
}