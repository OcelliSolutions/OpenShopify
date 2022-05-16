using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class PageController : IPageController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("pages.json")]
    public Task RetrieveListOfPagesAsync(string? created_at_max, string? created_at_min, string? fields, string? handle,
        string limit, string? published_at_max, string? published_at_min, string published_status, string? since_id,
        string? title, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("pages.json")]
    public Task CreatePageAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("pages/count.json")]
    public Task RetrievePageCountAsync(string? created_at_max, string? created_at_min, string? published_at_max,
        string? published_at_min, string published_status, string? title, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("pages/{page_id}.json")]
    public Task RetrieveSinglePageByItsIDAsync(string page_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("pages/{page_id}.json")]
    public Task UpdatePageAsync(string page_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("pages/{page_id}.json")]
    public Task DeletePageAsync(string page_id)
    {
        throw new NotImplementedException();
    }
}