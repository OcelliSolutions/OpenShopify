using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class ArticleController : ArticleControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("blogs/{blog_id:long}/articles.json")]
    [ProducesResponseType(typeof(ArticleList), StatusCodes.Status200OK)]
    public override Task ListArticlesFromBlog(long blog_id, string? author = null, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? handle = null, int? limit = null,
        string? page_info = null, DateTimeOffset? published_at_max = null, DateTimeOffset? published_at_min = null,
        string? published_status = null, long? since_id = null, string? tag = null, DateTimeOffset? updated_at_max = null,
        DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("blogs/{blog_id:long}/articles.json")]
    [ProducesResponseType(typeof(ArticleItem), StatusCodes.Status201Created)]
    public override Task CreateArticleForBlog(CreateArticleForBlogRequest request, long blog_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("blogs/{blog_id:long}/articles/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountArticlesFromBlog(long? blog_id = null, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, DateTimeOffset? updated_at_max = null,
        DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("blogs/{blog_id:long}/articles/{article_id:long}.json")]
    [ProducesResponseType(typeof(ArticleItem), StatusCodes.Status200OK)]
    public override Task GetArticle([Required] long article_id, [Required] long blog_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("blogs/{blog_id:long}/articles/{article_id:long}.json")]
    [ProducesResponseType(typeof(ArticleItem), StatusCodes.Status200OK)]
    public override Task UpdateArticle([Required] UpdateArticleRequest request, [Required] long article_id,
        [Required] long blog_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("blogs/{blog_id:long}/articles/{article_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteArticle([Required] long article_id, [Required] long blog_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("articles/authors.json")]
    [ProducesResponseType(typeof(AuthorList), StatusCodes.Status200OK)]
    public override Task ListArticleAuthors() => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("articles/tags.json")]
    [ProducesResponseType(typeof(TagList), StatusCodes.Status200OK)]
    public override Task ListArticleTags(int? limit = null, string? page_info = null, string? popular = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("blogs/{blog_id:long}/articles/tags.json")]
    [ProducesResponseType(typeof(TagList), StatusCodes.Status200OK)]
    public override Task ListArticleTagsFromSpecificBlog([Required] long blog_id, int? limit = null,
        string? page_info = null, string? popular = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("articles/{article_id:long}.json")]
    [ProducesResponseType(typeof(ArticleItem), StatusCodes.Status200OK)]
    public override Task DeleteImageFromArticle(long article_id) => throw new NotImplementedException();
}