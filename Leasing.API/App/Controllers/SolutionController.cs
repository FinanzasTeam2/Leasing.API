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
public class SolutionController:ControllerBase
{
    private readonly ISolutionService _solutionService;
    private readonly IMapper _mapper;
    
    public SolutionController(ISolutionService solutionService, IMapper mapper)
    {
        _solutionService = solutionService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<SolutionResource>> GetAllAsync()
    {
        var solutions = await _solutionService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Solution>, IEnumerable<SolutionResource>>(solutions);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("Solution Information to Add", Required = true)] SaveSolutionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var solution = _mapper.Map<SaveSolutionResource, Solution>(resource);

        var result = await _solutionService.SaveAsync(solution);

        if (!result.Success)
            return BadRequest(result.Message);

        var solutionResource = _mapper.Map<Solution, SolutionResource>(result.Resource);

        return Ok(solutionResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSolutionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveSolutionResource, Solution>(resource);

        var result = await _solutionService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<Solution, SolutionResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _solutionService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<Solution, SolutionResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
}