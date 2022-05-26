using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class BlogFixture : SharedFixture, IAsyncLifetime
{
    public List<Blog> CreatedBlogs = new();
    public OnlineStoreService Service;

    public BlogFixture() =>
        Service = new OnlineStoreService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteBlogAsync_CanDelete();
    }
    
    public async Task DeleteBlogAsync_CanDelete()
    {
        foreach (var blog in CreatedBlogs)
        {
            _ = await Service.Blog.DeleteBlogAsync(blog.Id);
        }
        CreatedBlogs.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class BlogTests : IClassFixture<BlogFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public BlogTests(BlogFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private BlogFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateBlogAsync_CanUpdate()
    {
        var originalBlog = Fixture.CreatedBlogs.First();
        var request = new UpdateBlogRequest
        {
            Blog = new UpdateBlog
            {
                Id = originalBlog.Id,
                Title = Fixture.UniqueString()
            }
        };
        var response = await Fixture.Service.Blog.UpdateBlogAsync(request.Blog.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedBlogs.Remove(originalBlog);
        Fixture.CreatedBlogs.Add(response.Result.Blog);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateBlogAsync_CanCreate()
    {
        var request = Fixture.CreateBlogRequest();
        var response = await Fixture.Service.Blog.CreateBlogAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedBlogs.Add(response.Result.Blog);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateBlogAsync_IsUnprocessableEntityError()
    {
        var request = new CreateBlogRequest
        {
            Blog = new CreateBlog()
        };
        await Assert.ThrowsAsync<ApiException<BlogError>>(async () =>
            await Fixture.Service.Blog.CreateBlogAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountBlogsAsync_CanGet()
    {
        var response = await Fixture.Service.Blog.CountBlogsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListBlogsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Blog.ListBlogsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var blog in response.Result.Blogs)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(blog, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Blogs.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetBlogAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedBlogs.Any(), "Must be run with create test");
        var blog = Fixture.CreatedBlogs.First();
        var response = await Fixture.Service.Blog.GetBlogAsync(blog.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Blog, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete


    [SkippableFact, TestPriority(99)]
    public async Task DeleteBlogAsync_CanDelete()
    {
        await Fixture.DeleteBlogAsync_CanDelete();
    }

    #endregion Delete
    }