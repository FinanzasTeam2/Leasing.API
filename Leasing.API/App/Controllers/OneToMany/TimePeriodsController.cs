using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Leasing.API.App.Resources.Period;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasing.API.App.Controllers.OneToMany;

[ApiController]
[Route("/api/v1/times/{timeId}/periods")]
public class TimePeriodsController
{
    private readonly IPeriodService _periodService;
    private readonly IMapper _mapper;

    public TimePeriodsController(IPeriodService periodService, IMapper mapper)
    {
        _periodService = periodService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all Periods for given Time",
        Description = "Get existing Periods associated with the specified Time",
        OperationId = "GetTimePeriods",
        Tags = new[] {"Times"})]
    public async Task<IEnumerable<PeriodResource>> GetAllByTimeIdAsync(int timeId)
    {
        var periods = await _periodService.ListByTimeIdAsync(timeId);
        var resources = _mapper.Map<IEnumerable<Period>, IEnumerable<PeriodResource>>(periods);
        return resources;
    }
}