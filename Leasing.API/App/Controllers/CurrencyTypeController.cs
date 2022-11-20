using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Microsoft.AspNetCore.Mvc;

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
        var currencyTypes = await _currencyTypeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<CurrencyType>, IEnumerable<CurrencyTypeResource>>(currencyTypes);

        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<CurrencyTypeResource> GetByIdAsync(int id)
    {
        var currencyType = await _currencyTypeService.FindByIdAsync(id);
        var resources = _mapper.Map<CurrencyType, CurrencyTypeResource>(currencyType);
        
        return resources;
    }
}