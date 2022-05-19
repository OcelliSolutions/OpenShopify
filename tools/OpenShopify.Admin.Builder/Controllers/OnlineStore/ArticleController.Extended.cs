using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class ArticleController : ArticleControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("blogs/{blog_id:long}/articles.json")]
    public override Task RetrieveListOfAllArticlesFromBlog(long blog_id, string? author, DateTime? created_at_max,
        DateTime? created_at_min, string? fields, string? handle, int? limit, string? page_info, DateTime? published_at_max,
        DateTime? published_at_min, string published_status, int? since_id, string? tag, DateTime? updated_at_max,
        DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("blogs/{blog_id:long}/articles.json")]
    public override Task CreateArticleForBlog(CreateArticleRequest request, long blog_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("blogs/{blog_id:long}/articles/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfAllArticlesFromBlog(long blog_id, DateTime? created_at_max, DateTime? created_at_min,
        DateTime? published_at_max, DateTime? published_at_min, string published_status, DateTime? updated_at_max,
        DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("blogs/{blog_id:long}/articles/{article_id:long}.json")]
    public override Task ReceiveSingleArticle(long article_id, long blog_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("blogs/{blog_id:long}/articles/{article_id:long}.json")]
    public override Task UpdateArticle(UpdateArticleRequest request, long article_id, long blog_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("blogs/{blog_id:long}/articles/{article_id:long}.json")]
    public override Task DeleteArticle(long article_id, long blog_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("articles/authors.json")]
    public override Task RetrieveListOfAllArticleAuthors()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("articles/tags.json")]
    public override Task RetrieveListOfAllArticleTags(int? limit, string? page_info, string? popular)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("blogs/{blog_id:long}/articles/tags.json")]
    public override Task RetrieveListOfAllArticleTagsFromSpecificBlog(long blog_id, int? limit, string? page_info, string? popular)
    {
        throw new NotImplementedException();
    }

}

public class ArticleItem
{
}