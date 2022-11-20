using AutoMapper;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;

namespace Leasing.API.App.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<CurrencyType,CurrencyTypeResource>();
        CreateMap<User,UserResource>();
        CreateMap<LeasingData,LeasingDataResource>();
        CreateMap<LeasingResult,LeasingResultResource>();
        CreateMap<LeasingMethod,LeasingMethodResource>();
    }
}