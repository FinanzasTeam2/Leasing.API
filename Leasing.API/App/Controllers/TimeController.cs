using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.API.App.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
public class TimeController:ControllerBase
{
    private readonly ITimeService _timeService;
    private readonly IMapper _mapper;
    
    public TimeController(ITimeService timeService, IMapper mapper)
    {
        _timeService = timeService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<TimeResource>> GetAllAsync()
    {
        var times = await _timeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Time>, IEnumerable<TimeResource>>(times);

        return resources;
    }
}