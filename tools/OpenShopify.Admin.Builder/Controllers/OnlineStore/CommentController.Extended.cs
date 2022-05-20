using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class CommentController : CommentControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("comments.json")]
    public override Task ListComments(DateTime? created_at_max, DateTime? created_at_min, string? fields, int? limit, string? page_info,
        DateTime? published_at_max, DateTime? published_at_min, string published_status, int? since_id, string? status,
        DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments.json")]
    public override Task CreateCommentForArticle(CreateCommentRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("comments/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task GetCountOfComments(DateTime? created_at_max, DateTime? created_at_min, DateTime? published_at_max,
        DateTime? published_at_min, string published_status, string? status, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("comments/{comment_id:long}.json")]
    public override Task GetCommentByItsID(long comment_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("comments/{comment_id:long}.json")]
    public override Task UpdateCommentOfArticle(UpdateCommentRequest request, long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/spam.json")]
    public override Task MarkCommentAsSpam(long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/not_spam.json")]
    public override Task MarkCommentAsNotSpam(long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/approve.json")]
    public override Task ApproveComment(long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/remove.json")]
    public override Task DeleteComment(long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/restore.json")]
    public override Task RestorePreviouslyRemovedComment(long comment_id)
    {
        throw new NotImplementedException();
    }
}