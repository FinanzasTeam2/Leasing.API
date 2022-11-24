using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Core.Comunication;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Resources;
using Leasing.API.App.Shared.Extensions;
using Leasing.API.Shared.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasing.API.App.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
public class LeasingResultController:ControllerBase
{
    private readonly ILeasingResultService _leasingResultService;
    private readonly IMapper _mapper;
    
    public LeasingResultController(ILeasingResultService leasingResultService, IMapper mapper)
    {
        _leasingResultService = leasingResultService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<LeasingResultResource>> GetAllAsync()
    {
        var leasingResult = await _leasingResultService.ListAsync();
        var resources = _mapper.Map<IEnumerable<LeasingResult>, IEnumerable<LeasingResultResource>>(leasingResult);

        return resources;
    }

    [HttpGet("{userId}")]
    public async Task<IEnumerable<LeasingResultResource>> FindByUserIdAsync(int userId)
    {
        var leasingResult = await _leasingResultService.FindByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<LeasingResult>, IEnumerable<LeasingResultResource>>(leasingResult);
        return resources;
    }


    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("LeasingResult Information to Add", Required = true)] SaveLeasingResultResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var leasingResult = _mapper.Map<SaveLeasingResultResource, LeasingResult>(resource);

        var result = await _leasingResultService.SaveAsync(leasingResult);

        if (!result.Success)
            return BadRequest(result.Message);

        var leasingResultResource = _mapper.Map<LeasingResult, LeasingResultResource>(result.Resource);

        return Ok(leasingResultResource);
    }
}