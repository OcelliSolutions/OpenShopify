using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class PageController : PageControllerBase
{
    public override Task RetrieveListOfPages(string? created_at_max = null, string? created_at_min = null, string? fields = null,
        string? handle = null, string? limit = "50", string? published_at_max = null, string? published_at_min = null,
        string? published_status = "any", string? since_id = null, string? title = null, string? updated_at_max = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreatePage()
    {
        throw new NotImplementedException();
    }

    public override Task RetrievePageCount(string? created_at_max = null, string? created_at_min = null, string? published_at_max = null,
        string? published_at_min = null, string? published_status = "any", string? title = null,
        string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSinglePageByItsID(string page_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdatePage(string page_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeletePage(string page_id)
    {
        throw new NotImplementedException();
    }
}