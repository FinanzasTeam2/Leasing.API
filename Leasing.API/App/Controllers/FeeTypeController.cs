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
public class FeeTypeController:ControllerBase
{
    private readonly IFeeTypeService _feeTypeService;
    private readonly IMapper _mapper;
    
    public FeeTypeController(IFeeTypeService feeTypeService, IMapper mapper)
    {
        _feeTypeService = feeTypeService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<FeeTypeResource>> GetAllAsync()
    {
        var brandVehicles = await _feeTypeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<FeeType>, IEnumerable<FeeTypeResource>>(brandVehicles);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("FeeType Information to Add", Required = true)] SaveFeeTypeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveFeeTypeResource, FeeType>(resource);

        var result = await _feeTypeService.SaveAsync(brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<FeeType, FeeTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFeeTypeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveFeeTypeResource, FeeType>(resource);

        var result = await _feeTypeService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<FeeType, FeeTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _feeTypeService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<FeeType, FeeTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
}