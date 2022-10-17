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
public class AssetTypeController:ControllerBase
{
    private readonly IAssetTypeService _assetTypeService;
    private readonly IMapper _mapper;
    
    public AssetTypeController(IAssetTypeService assetTypeService, IMapper mapper)
    {
        _assetTypeService = assetTypeService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<AssetTypeResource>> GetAllAsync()
    {
        var brandVehicles = await _assetTypeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<AssetType>, IEnumerable<AssetTypeResource>>(brandVehicles);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("AssetType Information to Add", Required = true)] SaveAssetTypeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveAssetTypeResource, AssetType>(resource);

        var result = await _assetTypeService.SaveAsync(brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<AssetType, AssetTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAssetTypeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveAssetTypeResource, AssetType>(resource);

        var result = await _assetTypeService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<AssetType, AssetTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _assetTypeService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<AssetType, AssetTypeResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    
}