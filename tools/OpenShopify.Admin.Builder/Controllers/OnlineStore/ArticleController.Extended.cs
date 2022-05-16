using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class ArticleController : IArticleController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles.json")]
    public Task RetrieveListOfAllArticlesFromBlogAsync(string blog_id, string? author, string? created_at_max,
        string? created_at_min, string? fields, string? handle, string limit, string? published_at_max,
        string? published_at_min, string published_status, string? since_id, string? tag, string? updated_at_max,
        string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles.json")]
    public Task CreateArticleForBlogAsync(string blog_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/count.json")]
    public Task RetrieveCountOfAllArticlesFromBlogAsync(string blog_id, string? created_at_max, string? created_at_min,
        string? published_at_max, string? published_at_min, string published_status, string? updated_at_max,
        string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/{article_id}.json")]
    public Task ReceiveSingleArticleAsync(string article_id, string blog_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/{article_id}.json")]
    public Task UpdateArticleAsync(string article_id, string blog_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/{article_id}.json")]
    public Task DeleteArticleAsync(string article_id, string blog_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("articles/authors.json")]
    public Task RetrieveListOfAllArticleAuthorsAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("articles/tags.json")]
    public Task RetrieveListOfAllArticleTagsAsync(string? limit, string? popular)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/tags.json")]
    public Task RetrieveListOfAllArticleTagsFromSpecificBlogAsync(string blog_id, string? limit, string? popular)
    {
        throw new NotImplementedException();
    }
}