using System.ComponentModel.DataAnnotations;
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
    public override Task ListComments(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null, string? fields = null, int? limit = null, string? page_info = null,
        DateTimeOffset? published_at_max = null, DateTimeOffset? published_at_min = null, string? published_status = null, long? since_id = null, string? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments.json")]
    public override Task CreateCommentForArticle([Required] CreateCommentRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("comments/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountComments(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null, DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, string? status = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("comments/{comment_id:long}.json")]
    public override Task GetCommentByItsID([Required] long comment_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("comments/{comment_id:long}.json")]
    public override Task UpdateCommentOfArticle([Required] UpdateCommentRequest request, [Required] long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/spam.json")]
    public override Task MarkCommentAsSpam([Required] long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/not_spam.json")]
    public override Task MarkCommentAsNotSpam([Required] long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/approve.json")]
    public override Task ApproveComment([Required] long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/remove.json")]
    public override Task DeleteComment([Required] long comment_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("comments/{comment_id:long}/restore.json")]
    public override Task RestorePreviouslyDeletedComment(long comment_id)
    {
        throw new NotImplementedException();
    }
}