using Leasing.API.App.Domain.Models;
using Leasing.API.Shared.Domain.Core.Comunication;

namespace Leasing.API.App.Domain.Core.Comunication;

public class VATResponse:BaseResponse<VAT>
{
    public VATResponse(VAT resource) : base(resource)
    {
    }

    public VATResponse(string message) : base(message)
    {
    }
}