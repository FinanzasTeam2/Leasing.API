using AutoMapper;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;

namespace Leasing.API.App.Mapping;

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCurrencyTypeResource,CurrencyType>();
        CreateMap<SaveUserResource,User>();
        CreateMap<SaveLeasingDataResource,LeasingData>();
        CreateMap<SaveLeasingResultResource,LeasingResult>();
        CreateMap<SaveLeasingMethodResource,LeasingMethod>();
    }
}