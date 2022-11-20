using AutoMapper;
using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasing.API.App.Controllers.OneToMany;

[ApiController]
[Route("api/v1/user/{userId}/leasingdatas")]
public class UserLeasingDataController
{
    private readonly ILeasingDataService _leasingDataService;
    private readonly IMapper _mapper;

    public UserLeasingDataController(ILeasingDataService leasingDataService, IMapper mapper)
    {
        _leasingDataService = leasingDataService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All LeasingDatas for given User",
        Description = "Get existing LeasingData associated with the specified User",
        OperationId = "GetUserLeasingDatas",
        Tags = new[] {"User"})]
    public async Task<IEnumerable<LeasingDataResource>> GetAllByUserIdAsync(int userId)
    {
        var leasingData = await _leasingDataService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<LeasingData>, IEnumerable<LeasingDataResource>>(leasingData);
        return resources;
    }
}