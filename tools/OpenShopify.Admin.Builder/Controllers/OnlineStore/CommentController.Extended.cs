using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class CommentController : ICommentController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("comments.json")]
    public Task RetrieveListOfCommentsAsync(string? created_at_max, string? created_at_min, string? fields, string limit,
        string? published_at_max, string? published_at_min, string published_status, string? since_id, string? status,
        string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("comments.json")]
    public Task CreateCommentForArticleAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("comments/count.json")]
    public Task RetrieveCountOfCommentsAsync(string? created_at_max, string? created_at_min, string? published_at_max,
        string? published_at_min, string published_status, string? status, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("comments/{comment_id}.json")]
    public Task RetrieveSingleCommentByItsIDAsync(string comment_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("comments/{comment_id}.json")]
    public Task UpdateCommentOfArticleAsync(string comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("comments/{comment_id}/spam.json")]
    public Task MarkCommentAsSpamAsync(string comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("comments/{comment_id}/not_spam.json")]
    public Task MarkCommentAsNotSpamAsync(string comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("comments/{comment_id}/approve.json")]
    public Task ApproveCommentAsync(string comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("comments/{comment_id}/remove.json")]
    public Task RemoveCommentAsync(string comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("comments/{comment_id}/restore.json")]
    public Task RestorePreviouslyRemovedCommentAsync(string comment_id)
    {
        throw new NotImplementedException();
    }
}