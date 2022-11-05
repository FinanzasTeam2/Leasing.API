using AutoMapper;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Resources;
using Leasing.API.App.Resources.Period;

namespace Leasing.API.App.Mapping;

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAssetTypeResource,AssetType>();
        CreateMap<SaveCurrencyTypeResource,CurrencyType>();
        CreateMap<SaveFeeResource,Fee>();
        CreateMap<SaveFeeTypeResource,FeeType>();
        CreateMap<SavePeriodResource,Period>();
        CreateMap<SaveRateTypeResource,RateType>();
        CreateMap<SaveSolutionResource,Solution>();
        CreateMap<SaveUserProfileResource,UserProfile>();
        CreateMap<SaveTimeResource,Time>();
        CreateMap<SaveVATResource,VAT>();
    }
}