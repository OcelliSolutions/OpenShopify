using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class PageController : PageControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("pages.json")]
    public override Task RetrieveListOfPages(DateTime? created_at_max, DateTime? created_at_min, string? fields, string? handle,
        int? limit, string? page_info, DateTime? published_at_max, DateTime? published_at_min, string published_status, int? since_id,
        string? title, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("pages.json")]
    public override Task CreatePage(CreatePageRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("pages/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task RetrievePageCount(DateTime? created_at_max, DateTime? created_at_min, DateTime? published_at_max,
        DateTime? published_at_min, string published_status, string? title, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("pages/{page_id:long}.json")]
    public override Task RetrieveSinglePageByItsID(long page_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("pages/{page_id:long}.json")]
    public override Task UpdatePage(UpdatePageRequest request, long page_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("pages/{page_id:long}.json")]
    public override Task DeletePage(long page_id)
    {
        throw new NotImplementedException();
    }
}
