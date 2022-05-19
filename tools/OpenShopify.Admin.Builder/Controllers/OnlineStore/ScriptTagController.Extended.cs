using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class ScriptTagController : ScriptTagControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("script_tags.json")]
    public override Task RetrieveListOfAllScriptTags(DateTime? created_at_max, DateTime? created_at_min, string? fields, int? limit, string? page_info,
        int? since_id, string? src, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("script_tags.json")]
    public override Task CreateNewScriptTag(CreateScriptTagRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("script_tags/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfAllScriptTags(string? src)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("script_tags/{script_tag_id:long}.json")]
    public override Task RetrieveSingleScriptTag(long script_tag_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("script_tags/{script_tag_id:long}.json")]
    public override Task UpdateScriptTag(UpdateScriptTagRequest request, long script_tag_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("script_tags/{script_tag_id:long}.json")]
    public override Task DeleteScriptTag(long script_tag_id)
    {
        throw new NotImplementedException();
    }
}
