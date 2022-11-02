using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasing.API.App.Controllers.OneToMany;

[ApiController]
[Route("/api/v1/periods/{periodId}/times")]
public class PeriodTimesController
{
    private readonly IPeriodService _periodService;
    private readonly IMapper _mapper;

    public PeriodTimesController(IPeriodService periodService, IMapper mapper)
    {
        _periodService = periodService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all Times for given Period",
        Description = "Get existing Times associated with the specified Period",
        OperationId = "GetPeriodTimes",
        Tags = new[] {"Periods"})]
    public async Task<IEnumerable<PeriodResource>> GetAllByTimeIdAsync(int periodId)
    {
        var periods = await _periodService.ListByTimeIdAsync(periodId);
        var resources = _mapper.Map<IEnumerable<Period>, IEnumerable<PeriodResource>>(periods);
        return resources;
    }
}