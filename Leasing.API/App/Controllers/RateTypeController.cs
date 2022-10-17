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
public class RateTypeController:ControllerBase
{
    private readonly IRateTypeService _RateTypeService;
    private readonly IMapper _mapper;
    
    public RateTypeController(IRateTypeService RateTypeService, IMapper mapper)
    {
        _RateTypeService = RateTypeService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<RateTypeResource>> GetAllAsync()
    {
        var brandVehicles = await _RateTypeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<RateType>, IEnumerable<RateTypeResource>>(brandVehicles);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("RateType Information to Add", Required = true)] SaveRateTypeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveRateTypeResource, RateType>(resource);

        var result = await _RateTypeService.SaveAsync(brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<RateType, RateTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRateTypeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveRateTypeResource, RateType>(resource);

        var result = await _RateTypeService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<RateType, RateTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _RateTypeService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<RateType, RateTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
}