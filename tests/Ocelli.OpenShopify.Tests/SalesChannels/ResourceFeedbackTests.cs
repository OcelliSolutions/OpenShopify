using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.SalesChannels;

public class ResourceFeedbackFixture : SharedFixture, IAsyncLifetime
{
    public List<ResourceFeedback> CreatedResourceFeedbacks = new();
    public SalesChannelsService Service;

    public ResourceFeedbackFixture() =>
        Service = new SalesChannelsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ResourceFeedbackTests : IClassFixture<ResourceFeedbackFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ResourceFeedbackTests(ResourceFeedbackFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private ResourceFeedbackFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListResourceFeedbacksAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.ResourceFeedback.ListResourceFeedbacksAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var resourceFeedback in response.Result.ResourceFeedback)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(resourceFeedback, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.ResourceFeedback.Any(), "No results returned. Unable to test");
    }

    #endregion Read

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateResourceFeedbackAsync_CanCreate()
    {
        var request = new CreateResourceFeedbackRequest
        {
            ResourceFeedback = new CreateResourceFeedback
            {
                State = ResourceFeedbackState.RequiresAction,
                Messages = new List<string>
                {
                    "is not connected. Connect your account to use this sales channel."
                },
                FeedbackGeneratedAt = DateTimeOffset.Now
            }
        };
        var response = await Fixture.Service.ResourceFeedback.CreateResourceFeedbackAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedResourceFeedbacks.Add(response.Result.ResourceFeedback);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateResourceFeedbackAsync_IsUnprocessableEntityError()
    {
        var request = new CreateResourceFeedbackRequest
        {
            ResourceFeedback = new CreateResourceFeedback()
        };
        await Assert.ThrowsAsync<ApiException<ResourceFeedbackError>>(async () =>
            await Fixture.Service.ResourceFeedback.CreateResourceFeedbackAsync(request));
    }

    #endregion Create
}