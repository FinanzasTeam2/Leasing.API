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
public class PeriodController:ControllerBase
{
    private readonly IPeriodService _PeriodService;
    private readonly IMapper _mapper;
    
    public PeriodController(IPeriodService PeriodService, IMapper mapper)
    {
        _PeriodService = PeriodService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<PeriodResource>> GetAllAsync()
    {
        var brandVehicles = await _PeriodService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Period>, IEnumerable<PeriodResource>>(brandVehicles);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("Period Information to Add", Required = true)] SavePeriodResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SavePeriodResource, Period>(resource);

        var result = await _PeriodService.SaveAsync(brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<Period, PeriodResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePeriodResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SavePeriodResource, Period>(resource);

        var result = await _PeriodService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<Period, PeriodResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _PeriodService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<Period, PeriodResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
}