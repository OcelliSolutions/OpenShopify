using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class CommentController : CommentControllerBase
{
    public override Task RetrieveListOfComments(string? created_at_max = null, string? created_at_min = null, string? fields = null,
        string? limit = "50", string? published_at_max = null, string? published_at_min = null,
        string? published_status = "any", string? since_id = null, string? status = null, string? updated_at_max = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfComments(string? created_at_max = null, string? created_at_min = null,
        string? published_at_max = null, string? published_at_min = null, string? published_status = "any",
        string? status = null, string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleCommentByItsID(string comment_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateCommentOfArticle(string comment_id)
    {
        throw new NotImplementedException();
    }

    public override Task CreateCommentForArticle()
    {
        throw new NotImplementedException();
    }

    public override Task MarkCommentAsSpam(string comment_id)
    {
        throw new NotImplementedException();
    }

    public override Task MarkCommentAsNotSpam(string comment_id)
    {
        throw new NotImplementedException();
    }

    public override Task ApproveComment(string comment_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveComment(string comment_id)
    {
        throw new NotImplementedException();
    }

    public override Task RestorePreviouslyRemovedComment(string comment_id)
    {
        throw new NotImplementedException();
    }
}