using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentServiceTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ShippingAndFulfillmentService _service;
    private const string FulfillmentServicePrefix = "OpenShopify Fulfillment Test";

    public FulfillmentServiceTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ShippingAndFulfillmentService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    /// <summary>
    /// Create an fulfillment service first
    /// </summary>
    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentServiceAsync_CanCreate()
    {
        var name = $@"{FulfillmentServicePrefix} {Fixture.BatchId}";
        var email = $@"open+{Fixture.BatchId}@sample.com";
        var request = new CreateFulfillmentServiceRequest()
        {
            FulfillmentService = new CreateFulfillmentService()
            {
                Name = name,
                Email = email,
                Format = FulfillmentServiceFormat.json,
                CallbackUrl = "http://sample.com/callback"
            }
        };
        var created =
            await _service.FulfillmentService.CreateFulfillmentServiceAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);

        Assert.Equal(name, created.Result.FulfillmentService?.Name);
        Assert.NotNull(created.Result.FulfillmentService?.Id);
        Debug.Assert(created.Result.FulfillmentService != null, "created.CreatedFulfillmentServices != null");
        Fixture.CreatedFulfillmentServices.Add(created.Result.FulfillmentService);
    }

    /// <summary>
    /// Ensure that the created fulfillment service can be returned
    /// </summary>
    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentServiceAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        Skip.If(!Fixture.CreatedFulfillmentServices.Any(), "WARN: No data returned. Could not test");
        if (Fixture.CreatedFulfillmentServices.First() is not { Handle: { } }) return;
        var testFulfillmentService = Fixture.CreatedFulfillmentServices.First();

        var single =
            await _service.FulfillmentService.GetFulfillmentServiceAsync(testFulfillmentService.Id,
                CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(single, Fixture.MyShopifyUrl);

        Assert.NotNull(single.Result.FulfillmentService?.Id);
        Assert.Equal(testFulfillmentService.Handle, single.Result.FulfillmentService?.Handle);
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListFulfillmentServicesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var result =
            await _service.FulfillmentService.ListFulfillmentServicesAsync(FulfillmentServiceScope
                .current_client);
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        if (result.Result.FulfillmentServices != null && !result.Result.FulfillmentServices.Any())
        {
            Skip.If(result.Result.FulfillmentServices == null || !result.Result.FulfillmentServices.Any(),
                "WARN: No data returned. Could not test");
            return;
        }

        foreach (var token in result.Result.FulfillmentServices!)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }

        Assert.NotEmpty(result.Result.FulfillmentServices);
        Fixture.CreatedFulfillmentServices.AddRange(result.Result.FulfillmentServices.Where(fs =>
            !Fixture.CreatedFulfillmentServices.Exists(e => e.Id == fs.Id) &&
            fs.Name.StartsWith(FulfillmentServicePrefix)));
    }

    /// <summary>
    /// update the newly created fulfillment service
    /// </summary>
    [SkippableFact, TestPriority(30)]
    public async Task UpdateFulfillmentServiceAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedFulfillmentServices.Any(), "WARN: No data returned. Could not test");
        var testFulfillmentService = Fixture.CreatedFulfillmentServices.First();
        var updateRequest = new UpdateFulfillmentServiceRequest()
        {
            FulfillmentService = new UpdateFulfillmentService()
            {
                Id = testFulfillmentService.Id, 
                Name = testFulfillmentService.Name, 
                Email = @"open@sample.com"
            }
        };
        var updated =
            await _service.FulfillmentService.UpdateFulfillmentServiceAsync(
                updateRequest.FulfillmentService.Id, updateRequest,
                CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(updated, Fixture.MyShopifyUrl);

        Assert.NotNull(updated.Result.FulfillmentService?.Id);
        Assert.Equal(testFulfillmentService.Id, updated.Result.FulfillmentService?.Id);
    }

    [SkippableFact, TestPriority(40)]
    public async Task DeleteExistingFulfillmentServiceAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedFulfillmentServices.Count == 0, "WARN: No data returned. Could not test");
        foreach (var testFulfillmentService in Fixture.CreatedFulfillmentServices)
        {
            await _service.FulfillmentService.DeleteExistingFulfillmentServiceAsync(testFulfillmentService.Id,
                CancellationToken.None);
        }
    }
}
