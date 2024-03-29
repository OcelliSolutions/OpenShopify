using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class BlogController : BlogControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("blogs.json")]
    [ProducesResponseType(typeof(BlogList), StatusCodes.Status200OK)]
    public override Task ListBlogs(string? fields = null, string? handle = null, int? limit = null,
        string? page_info = null, long? since_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("blogs.json")]
    [ProducesResponseType(typeof(BlogItem), StatusCodes.Status201Created)]
    public override Task CreateBlog([Required] CreateBlogRequest request) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("blogs/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountBlogs() => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("blogs/{blog_id:long}.json")]
    [ProducesResponseType(typeof(BlogItem), StatusCodes.Status200OK)]
    public override Task GetBlog([Required] long blog_id, string? fields = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("blogs/{blog_id:long}.json")]
    [ProducesResponseType(typeof(BlogItem), StatusCodes.Status200OK)]
    public override Task UpdateBlog([Required] UpdateBlogRequest request, [Required] long blog_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("blogs/{blog_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteBlog([Required] long blog_id) => throw new NotImplementedException();
}