using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources.Period;
using Leasing.API.App.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasing.API.App.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
public class PeriodController:ControllerBase
{
    private readonly IPeriodService _periodService;
    private readonly IMapper _mapper;
    
    public PeriodController(IPeriodService periodService, IMapper mapper)
    {
        _periodService = periodService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PeriodResource>> GetAllAsync()
    {
        var periods = await _periodService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Period>, IEnumerable<PeriodResource>>(periods);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("Period Information to Add", Required = true)] SavePeriodResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var period = _mapper.Map<SavePeriodResource, Period>(resource);

        var result = await _periodService.SaveAsync(period);

        if (!result.Success)
            return BadRequest(result.Message);

        var periodResource = _mapper.Map<Period, PeriodResource>(result.Resource);

        return Ok(periodResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePeriodResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var period = _mapper.Map<SavePeriodResource, Period>(resource);

        var result = await _periodService.UpdateAsync(id, period);

        if (!result.Success)
            return BadRequest(result.Message);

        var periodResource = _mapper.Map<Period, PeriodResource>(result.Resource);

        return Ok(periodResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _periodService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var periodResource = _mapper.Map<Period, PeriodResource>(result.Resource);

        return Ok(periodResource);
    }
}