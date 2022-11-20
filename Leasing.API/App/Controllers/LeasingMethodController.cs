using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.API.App.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
public class LeasingMethodController:ControllerBase
{
    private readonly ILeasingMethodService _leasingMethodService;
    private readonly IMapper _mapper;
    
    public LeasingMethodController(ILeasingMethodService leasingMethodService, IMapper mapper)
    {
        _leasingMethodService = leasingMethodService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<LeasingMethodResource>> GetAllAsync()
    {
        var leasingMethods = await _leasingMethodService.ListAsync();
        var resources = _mapper.Map<IEnumerable<LeasingMethod>, IEnumerable<LeasingMethodResource>>(leasingMethods);

        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<LeasingMethodResource> GetByIdAsync(int id)
    {
        var leasingMethod = await _leasingMethodService.FindByIdAsync(id);
        var resources = _mapper.Map<LeasingMethod, LeasingMethodResource>(leasingMethod);
        
        return resources;
    }
}