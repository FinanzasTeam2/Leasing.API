using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class CurrencyTypeResponse:BaseResponse<CurrencyType>
{
    public CurrencyTypeResponse(CurrencyType resource) : base(resource)
    {
    }

    public CurrencyTypeResponse(string message) : base(message)
    {
    }
}