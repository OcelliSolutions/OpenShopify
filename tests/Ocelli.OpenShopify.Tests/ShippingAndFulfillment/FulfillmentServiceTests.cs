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
    public async Task CreateNewFulfillmentServiceAsync_CanCreate()
    {
        var name = $@"{FulfillmentServicePrefix} {Fixture.BatchId}";
        var email = $@"open+{Fixture.BatchId}@sample.com";
        var request = new FulfillmentServiceItem()
        {
            FulfillmentService = new FulfillmentService()
            {
                Name = name,
                Email = email,
                Format = FulfillmentServiceFormat.json
            }
        };
        var created =
            await _service.FulfillmentService.CreateNewFulfillmentServiceAsync(request, CancellationToken.None);
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
    public async Task ReceiveSingleFulfillmentServiceAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        Assert.NotNull(Fixture.CreatedFulfillmentServices.First().Id);
        if (Fixture.CreatedFulfillmentServices.First() is not { Handle: { } }) return;
        var testFulfillmentService = Fixture.CreatedFulfillmentServices.First();

        var single =
            await _service.FulfillmentService.ReceiveSingleFulfillmentServiceAsync(testFulfillmentService.Id ?? 0,
                CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(single, Fixture.MyShopifyUrl);

        Assert.NotNull(single.Result.FulfillmentService?.Id);
        Assert.Equal(testFulfillmentService.Handle, single.Result.FulfillmentService?.Handle);
    }

    [SkippableFact, TestPriority(20)]
    public async Task ReceiveListOfAllFulfillmentServicesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var result =
            await _service.FulfillmentService.ReceiveListOfAllFulfillmentServicesAsync(FulfillmentServiceScope
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
    public async Task ModifyExistingFulfillmentServiceAsync_CanUpdate()
    {
        var testFulfillmentService = Fixture.CreatedFulfillmentServices.First();
        Assert.NotNull(testFulfillmentService.Id);
        if (testFulfillmentService is not { Handle: { } }) return;

        var updateRequest = new FulfillmentServiceItem() { FulfillmentService = testFulfillmentService };
        updateRequest.FulfillmentService!.Email = @"open@sample.com";
        var updated =
            await _service.FulfillmentService.ModifyExistingFulfillmentServiceAsync(
                updateRequest.FulfillmentService.Id ?? 0, updateRequest,
                CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(updated, Fixture.MyShopifyUrl);

        Assert.NotNull(updated.Result.FulfillmentService?.Id);
        Assert.Equal(testFulfillmentService.Id, updated.Result.FulfillmentService?.Id);
    }

    [SkippableFact, TestPriority(40)]
    public async Task RemoveExistingFulfillmentServiceAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedFulfillmentServices.Count == 0);
        foreach (var testFulfillmentService in Fixture.CreatedFulfillmentServices)
        {
            await _service.FulfillmentService.RemoveExistingFulfillmentServiceAsync(testFulfillmentService.Id ?? 0,
                CancellationToken.None);
        }
    }
}
