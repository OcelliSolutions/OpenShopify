using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class ScriptTagController : IScriptTagController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("script_tags.json")]
    public Task RetrieveListOfAllScriptTagsAsync(string? created_at_max, string? created_at_min, string? fields, string limit,
        string? since_id, string? src, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("script_tags.json")]
    public Task CreateNewScriptTagAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("script_tags/count.json")]
    public Task RetrieveCountOfAllScriptTagsAsync(string? src)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("script_tags/{script_tag_id}.json")]
    public Task RetrieveSingleScriptTagAsync(string script_tag_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("script_tags/{script_tag_id}.json")]
    public Task UpdateScriptTagAsync(string script_tag_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("script_tags/{script_tag_id}.json")]
    public Task DeleteScriptTagAsync(string script_tag_id)
    {
        throw new NotImplementedException();
    }
}