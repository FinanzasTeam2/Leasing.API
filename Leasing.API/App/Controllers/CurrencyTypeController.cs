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
public class CurrencyTypeController:ControllerBase
{
    private readonly ICurrencyTypeService _currencyTypeService;
    private readonly IMapper _mapper;
    
    public CurrencyTypeController(ICurrencyTypeService currencyTypeService, IMapper mapper)
    {
        _currencyTypeService = currencyTypeService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<CurrencyTypeResource>> GetAllAsync()
    {
        var brandVehicles = await _currencyTypeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<CurrencyType>, IEnumerable<CurrencyTypeResource>>(brandVehicles);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("CurrencyType Information to Add", Required = true)] SaveCurrencyTypeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveCurrencyTypeResource, CurrencyType>(resource);

        var result = await _currencyTypeService.SaveAsync(brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<CurrencyType, CurrencyTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCurrencyTypeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveCurrencyTypeResource,CurrencyType>(resource);

        var result = await _currencyTypeService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<CurrencyType, CurrencyTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _currencyTypeService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<CurrencyType, CurrencyTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
}