using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class ScriptTagController : ScriptTagControllerBase
{
    public override Task RetrieveListOfAllScriptTags(string? created_at_max = null, string? created_at_min = null, string? fields = null,
        string? limit = "50", string? since_id = null, string? src = null, string? updated_at_max = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewScriptTag()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfAllScriptTags(string? src = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleScriptTag(string script_tag_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateScriptTag(string script_tag_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteScriptTag(string script_tag_id)
    {
        throw new NotImplementedException();
    }
}