using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class BlogController : BlogControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("blogs.json")]
    public override Task RetrieveListOfAllBlogs(string? fields, string? handle, int? limit, string? page_info, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("blogs.json")]
    public override Task CreateNewBlog(CreateBlogRequest request, string title)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("blogs/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task ReceiveCountOfAllBlogs()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("blogs/{blog_id:long}.json")]
    public override Task ReceiveSingleBlog(long blog_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("blogs/{blog_id:long}.json")]
    public override Task ModifyExistingBlog(UpdateBlogRequest request, long blog_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("blogs/{blog_id:long}.json")]
    public override Task RemoveExistingBlog(long blog_id)
    {
        throw new NotImplementedException();
    }
}