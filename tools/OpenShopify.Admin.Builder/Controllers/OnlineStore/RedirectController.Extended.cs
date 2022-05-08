using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class RedirectController : RedirectControllerBase
{
    public override Task RetrieveListOfURLRedirects(string? fields = null, string? limit = "50", string? path = null,
        string? since_id = null, string? target = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateRedirect()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfURLRedirects(string? path = null, string? target = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleRedirect(string redirect_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingRedirect(string redirect_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteRedirect(string redirect_id)
    {
        throw new NotImplementedException();
    }
}