using AutoMapper;
using Leasing.API.App.Domain.Models;


namespace Leasing.API.App.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<AssetType,AssetTypeResource>();
    }
}