using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.API.App.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
public class VATController:ControllerBase
{
    private readonly IVATService _VATService;
    private readonly IMapper _mapper;
    
    public VATController(IVATService VATService, IMapper mapper)
    {
        _VATService = VATService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<VATResource>> GetAllAsync()
    {
        var VATs = await _VATService.ListAsync();
        var resources = _mapper.Map<IEnumerable<VAT>, IEnumerable<VATResource>>(VATs);

        return resources;
    }
}