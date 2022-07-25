using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class CommentController : CommentControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("comments.json")]
    [ProducesResponseType(typeof(CommentList), StatusCodes.Status200OK)]
    public override Task ListComments(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        string? fields = null, int? limit = null, string? page_info = null,
        DateTimeOffset? published_at_max = null, DateTimeOffset? published_at_min = null,
        string? published_status = null, long? since_id = null, string? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("comments.json")]
    [ProducesResponseType(typeof(CommentItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CommentError), StatusCodes.Status400BadRequest)]
    public override Task CreateComment([Required] CreateCommentRequest request) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("comments/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountComments(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, string? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("comments/{comment_id:long}.json")]
    [ProducesResponseType(typeof(CommentItem), StatusCodes.Status200OK)]
    public override Task GetComment([Required] long comment_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("comments/{comment_id:long}.json")]
    [ProducesResponseType(typeof(CommentItem), StatusCodes.Status200OK)]
    public override Task UpdateComment([Required] UpdateCommentRequest ofArticleRequest, [Required] long comment_id) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="CommentControllerBase.MarkCommentAsSpam" />
    [HttpPost]
    [Route("comments/{comment_id:long}/spam.json")]
    [ProducesResponseType(typeof(CommentItem), StatusCodes.Status200OK)]
    public override Task MarkCommentAsSpam([Required] long comment_id) => throw new NotImplementedException();

    /// <inheritdoc cref="CommentControllerBase.MarkCommentAsNotSpam" />
    [HttpPost]
    [Route("comments/{comment_id:long}/not_spam.json")]
    [ProducesResponseType(typeof(CommentItem), StatusCodes.Status200OK)]
    public override Task MarkCommentAsNotSpam([Required] long comment_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("comments/{comment_id:long}/approve.json")]
    [ProducesResponseType(typeof(CommentItem), StatusCodes.Status200OK)]
    public override Task ApproveComment([Required] long comment_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("comments/{comment_id:long}/remove.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteComment([Required] long comment_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("comments/{comment_id:long}/restore.json")]
    [ProducesResponseType(typeof(CommentItem), StatusCodes.Status200OK)]
    public override Task RestorePreviouslyDeletedComment(long comment_id) => throw new NotImplementedException();
}