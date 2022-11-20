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
public class LeasingDataController:ControllerBase
{
    private readonly ILeasingDataService _leasingDataService;
    private readonly IMapper _mapper;
    
    public LeasingDataController(ILeasingDataService leasingDataService, IMapper mapper)
    {
        _leasingDataService = leasingDataService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<LeasingDataResource>> GetAllAsync()
    {
        var leasingData = await _leasingDataService.ListAsync();
        var resources = _mapper.Map<IEnumerable<LeasingData>, IEnumerable<LeasingDataResource>>(leasingData);

        return resources;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("LeasingData Information to Add", Required = true)] SaveLeasingDataResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var leasingData = _mapper.Map<SaveLeasingDataResource, LeasingData>(resource);

        var result = await _leasingDataService.SaveAsync(leasingData);

        if (!result.Success)
            return BadRequest(result.Message);

        var leasingDataResource = _mapper.Map<LeasingData, LeasingDataResource>(result.Resource);

        return Ok(leasingDataResource);
    }
}