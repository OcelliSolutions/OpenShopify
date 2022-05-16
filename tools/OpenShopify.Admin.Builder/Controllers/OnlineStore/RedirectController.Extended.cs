using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class RedirectController : IRedirectController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("redirects.json")]
    public Task RetrieveListOfURLRedirectsAsync(string? fields, string limit, string? path, string? since_id, string? target)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("redirects.json")]
    public Task CreateRedirectAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("redirects/count.json")]
    public Task RetrieveCountOfURLRedirectsAsync(string? path, string? target)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("redirects/{redirect_id}.json")]
    public Task RetrieveSingleRedirectAsync(string redirect_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("redirects/{redirect_id}.json")]
    public Task UpdateExistingRedirectAsync(string redirect_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("redirects/{redirect_id}.json")]
    public Task DeleteRedirectAsync(string redirect_id)
    {
        throw new NotImplementedException();
    }
}