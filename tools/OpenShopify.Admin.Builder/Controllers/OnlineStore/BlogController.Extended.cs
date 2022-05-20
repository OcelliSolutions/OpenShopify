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
    public override Task ListBlogs(string? fields, string? handle, int? limit, string? page_info, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("blogs.json")]
    public override Task CreateBlog(CreateBlogRequest request, string title)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("blogs/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task GetCountOfAllBlogs()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("blogs/{blog_id:long}.json")]
    public override Task GetBlog(long blog_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("blogs/{blog_id:long}.json")]
    public override Task UpdateBlog(UpdateBlogRequest request, long blog_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("blogs/{blog_id:long}.json")]
    public override Task DeleteExistingBlog(long blog_id)
    {
        throw new NotImplementedException();
    }
}