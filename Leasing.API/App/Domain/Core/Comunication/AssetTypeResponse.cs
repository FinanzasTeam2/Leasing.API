using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class AssetTypeResponse:BaseResponse<AssetType>
{
    public AssetTypeResponse(AssetType resource) : base(resource)
    {
    }

    public AssetTypeResponse(string message) : base(message)
    {
    }
}