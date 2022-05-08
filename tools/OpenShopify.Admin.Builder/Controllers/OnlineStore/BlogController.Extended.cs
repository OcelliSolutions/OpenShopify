using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class BlogController : BlogControllerBase
{
    public override Task RetrieveListOfAllBlogs(string? fields = null, string? handle = null, string? limit = "50",
        string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewBlog(string title)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveCountOfAllBlogs()
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveSingleBlog(string blog_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingBlog(string blog_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveExistingBlog(string blog_id)
    {
        throw new NotImplementedException();
    }
}