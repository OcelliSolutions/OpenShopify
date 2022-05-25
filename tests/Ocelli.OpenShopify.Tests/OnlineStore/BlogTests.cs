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
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class BlogTests : IClassFixture<BlogFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly OnlineStoreService _service;

    public BlogTests(ITestOutputHelper testOutputHelper, BlogFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new OnlineStoreService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private BlogFixture Fixture { get; }

    #region Create

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountBlogsAsync_CanGet()
    {
        var response = await _service.Blog.CountBlogsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListBlogsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.Blog.ListBlogsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var blog in response.Result.Blogs)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(blog, Fixture.MyShopifyUrl);
            if (blog.Title != null && blog.Title.StartsWith(Fixture.BatchId)
                                        && !Fixture.CreatedBlogs.Exists(w => w.Id == blog.Id))
                Fixture.CreatedBlogs.Add(blog);
        }
        var list = response.Result.Blogs;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetBlogAsync_AdditionalPropertiesAreEmpty()
    {
        var blogListResponse = await _service.Blog.ListBlogsAsync(limit: 1);
        Skip.If(!blogListResponse.Result.Blogs.Any(), "No results returned. Unable to test");
        var response = await _service.Blog.GetBlogAsync(blogListResponse.Result.Blogs.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Blog, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetBlogAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedBlogs.Any(), "No results returned. Unable to test");
        var blog = Fixture.CreatedBlogs.First();
        var response = await _service.Blog.GetBlogAsync(blog.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Blog, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}
