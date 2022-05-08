using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class ArticleController : ArticleControllerBase
{
    public override Task RetrieveListOfAllArticlesFromBlog(string blog_id, string? author = null, string? created_at_max = null,
        string? created_at_min = null, string? fields = null, string? handle = null, string? limit = "50",
        string? published_at_max = null, string? published_at_min = null, string? published_status = "any",
        string? since_id = null, string? tag = null, string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateArticleForBlog(string blog_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfAllArticlesFromBlog(string blog_id, string? created_at_max = null, string? created_at_min = null,
        string? published_at_max = null, string? published_at_min = null, string? published_status = "any",
        string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveSingleArticle(string article_id, string blog_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateArticle(string article_id, string blog_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteArticle(string article_id, string blog_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfAllArticleAuthors()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfAllArticleTags(string? limit = null, string? popular = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfAllArticleTagsFromSpecificBlog(string blog_id, string? limit = null, string? popular = null)
    {
        throw new NotImplementedException();
    }
}