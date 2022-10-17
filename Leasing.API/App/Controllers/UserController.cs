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
public class UserController:ControllerBase
{
    private readonly IUserService _UserService;
    private readonly IMapper _mapper;
    
    public UserController(IUserService UserService, IMapper mapper)
    {
        _UserService = UserService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllAsync()
    {
        var brandVehicles = await _UserService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(brandVehicles);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("User Information to Add", Required = true)] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveUserResource, User>(resource);

        var result = await _UserService.SaveAsync(brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveUserResource, User>(resource);

        var result = await _UserService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _UserService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
}