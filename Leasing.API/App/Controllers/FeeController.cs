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
public class FeeController:ControllerBase
{
    private readonly IFeeService _feeService;
    private readonly IMapper _mapper;
    
    public FeeController(IFeeService feeService, IMapper mapper)
    {
        _feeService = feeService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<FeeResource>> GetAllAsync()
    {
        var brandVehicles = await _feeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Fee>, IEnumerable<FeeResource>>(brandVehicles);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("Fee Information to Add", Required = true)] SaveFeeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveFeeResource, Fee>(resource);

        var result = await _feeService.SaveAsync(brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<Fee, FeeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFeeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveFeeResource, Fee>(resource);

        var result = await _feeService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<Fee, FeeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _feeService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<Fee, FeeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
}