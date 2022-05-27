using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class CommentFixture : SharedFixture, IAsyncLifetime
{
    public Article Article = new();
    public Blog Blog = new();
    public List<Comment> CreatedComments = new();
    public OnlineStoreService Service;

    public CommentFixture() =>
        Service = new OnlineStoreService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        await CreateBlog();
        await CreateArticle();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteWebhookAsync_CanDelete();
        if (Blog.Id > 0)
        {
            _ = await Service.Blog.DeleteBlogAsync(Blog.Id);
        }
    }

    public async Task DeleteWebhookAsync_CanDelete()
    {
        foreach (var comment in CreatedComments)
        {
            _ = await Service.Comment.DeleteCommentAsync(comment.Id);
        }
        CreatedComments.Clear();
    }

    private async Task CreateBlog()
    {
        var request = CreateBlogRequest();
        var response = await Service.Blog.CreateBlogAsync(request);
        Blog = response.Result.Blog;
    }

    private async Task CreateArticle()
    {
        var request = CreateArticleRequest();
        var response = await Service.Article.CreateArticleAsync(Blog.Id, request);
        Article = response.Result.Article;
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CommentTests : IClassFixture<CommentFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public CommentTests(CommentFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private CommentFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateCommentAsync_CanUpdate()
    {
        var originalComment = Fixture.CreatedComments.First();
        var request = new UpdateCommentRequest
        {
            Comment = new UpdateComment
            {
                Id = originalComment.Id,
                Body = "You can even update through a web service."
            }
        };
        var response = await Fixture.Service.Comment.UpdateCommentAsync(request.Comment.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedComments.Remove(originalComment);
        Fixture.CreatedComments.Add(response.Result.Comment);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCommentAsync_CanCreate()
    {
        var request = new CreateCommentRequest
        {
            Comment = new CreateComment
            {
                Body = @"I like comments\nAnd I like posting them *RESTfully*.",
                Author = $@"{Fixture.FirstName} {Fixture.LastName}",
                Email = Fixture.Email,
                Ip = "107.20.160.121",
                BlogId = Fixture.Blog.Id,
                ArticleId = Fixture.Article.Id
            }
        };
        var response = await Fixture.Service.Comment.CreateCommentAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedComments.Add(response.Result.Comment);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCommentAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCommentRequest
        {
            Comment = new CreateComment()
        };
        await Assert.ThrowsAsync<ApiException<CommentError>>(async () =>
            await Fixture.Service.Comment.CreateCommentAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountCommentsAsync_CanGet()
    {
        var response = await Fixture.Service.Comment.CountCommentsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCommentsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Comment.ListCommentsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var comment in response.Result.Comments)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(comment, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Comments.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetCommentAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedComments.Any(), "Must be run with create test");
        var comment = Fixture.CreatedComments.First();
        var response = await Fixture.Service.Comment.GetCommentAsync(comment.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Comment, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteWebhookAsync_CanDelete()
    {
        await Fixture.DeleteWebhookAsync_CanDelete();
    }

    #endregion Delete
    }