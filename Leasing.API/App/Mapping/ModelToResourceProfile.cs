using AutoMapper;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;

namespace Leasing.API.App.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<AssetType,AssetTypeResource>();
        CreateMap<CurrencyType,CurrencyTypeResource>();
        CreateMap<Fee,FeeResource>();
        CreateMap<FeeType,FeeTypeResource>();
        CreateMap<Period,PeriodResource>();
        CreateMap<RateType,RateTypeResource>();
        CreateMap<Solution,SolutionResource>();
        CreateMap<UserProfile,UserProfileResource>();
        CreateMap<User,UserResource>();
        CreateMap<Time,TimeResource>();
        CreateMap<VAT,VATResource>();
    }
}