using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Leasing.API.App.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasing.API.App.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
public class UserProfileController:ControllerBase
{
    private readonly IUserProfileService _UserProfileService;
    private readonly IMapper _mapper;
    
    public UserProfileController(IUserProfileService UserProfileService, IMapper mapper)
    {
        _UserProfileService = UserProfileService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<UserProfileResource>> GetAllAsync()
    {
        var brandVehicles = await _UserProfileService.ListAsync();
        var resources = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(brandVehicles);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("UserProfile Information to Add", Required = true)] SaveUserProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);

        var result = await _UserProfileService.SaveAsync(brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);

        var result = await _UserProfileService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _UserProfileService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
}