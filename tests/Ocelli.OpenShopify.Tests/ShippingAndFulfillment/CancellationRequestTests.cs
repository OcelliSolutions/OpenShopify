using System.Collections.Generic;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
/*
public class CancellationRequestFixture : SharedFixture, IAsyncLifetime
{
    public EventsService Service;
    public List<Ocelli.OpenShopify.CancellationRequestItem> CreatedCancellationRequests = new();

    public CancellationRequestFixture()
    {
        Service = new EventsService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteCancellationRequestAsync_CanDelete();
    }

    public async Task DeleteCancellationRequestAsync_CanDelete()
    {
        foreach (var cancellationRequest in CreatedCancellationRequests)
        {
            _ = await Service.CancellationRequest.DeleteCancellationRequestAsync(cancellationRequest.Id);
        }
        CreatedCancellationRequests.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CancellationRequestTests : IClassFixture<CancellationRequestFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public CancellationRequestTests(CancellationRequestFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private CancellationRequestFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateCancellationRequestAsync_CanCreate()
    {
        var request = Fixture.CreateCancellationRequestRequest();
        var response = await Fixture.Service.CancellationRequest.CreateCancellationRequestAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCancellationRequests.Add(response.Result.CancellationRequest);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCancellationRequestAsync_EmptyBody_IsError()
    {
        var request = new CreateCancellationRequestRequest
        {
            CancellationRequest = new CreateCancellationRequest()
        };
        await Assert.ThrowsAsync<ApiException<CancellationRequestError>>(async () =>
            await Fixture.Service.CancellationRequest.CreateCancellationRequestAsync(request));
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCancellationRequestAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCancellationRequestRequest
        {
            CancellationRequest = new CreateCancellationRequest()
            {
                Topic = CancellationRequestTopic.AppUninstalled
            }
        };
        await Assert.ThrowsAsync<ApiException<CancellationRequestError>>(async () =>
            await Fixture.Service.CancellationRequest.CreateCancellationRequestAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountCancellationRequestsAsync_CanGet()
    {
        var response = await Fixture.Service.CancellationRequest.CountCancellationRequestsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListCancellationRequestsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.CancellationRequest.ListCancellationRequestsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var cancellationRequest in response.Result.CancellationRequests)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(cancellationRequest, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.CancellationRequests.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCancellationRequestAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCancellationRequests.Any(), "Must be run with create test");
        var cancellationRequest = Fixture.CreatedCancellationRequests.First();
        var response = await Fixture.Service.CancellationRequest.GetCancellationRequestAsync(cancellationRequest.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CancellationRequest, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateCancellationRequestAsync_CanUpdate()
    {
        var originalCancellationRequest = Fixture.CreatedCancellationRequests.First();
        var request = new UpdateCancellationRequestRequest()
        {
            CancellationRequest = new()
            {
                Id = originalCancellationRequest.Id,
                Fields = new List<string> { "id" }
            }
        };
        var response = await Fixture.Service.CancellationRequest.UpdateCancellationRequestAsync(originalCancellationRequest.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCancellationRequests.Remove(originalCancellationRequest);
        Fixture.CreatedCancellationRequests.Add(response.Result.CancellationRequest);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteCancellationRequestAsync_CanDelete()
    {
        await Fixture.DeleteCancellationRequestAsync_CanDelete();
    }

    #endregion Delete
}
*/