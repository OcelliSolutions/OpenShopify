using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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
    private const string FulfillmentServicePrefix = "OpenShopify Fulfillment Test";

    public FulfillmentServiceTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    /// <summary>
    /// Create an fulfillment service first
    /// </summary>
    [Fact, TestPriority(1)]
    public async void CreateNewFulfillmentServiceAsync_CanCreate()
    {
        var requiredPermissions = new List<AuthorizationScope> { AuthorizationScope.read_reports };
        var name = $@"{FulfillmentServicePrefix} {Fixture.BatchId}";
        var email = $@"open+{Fixture.BatchId}@sample.com";
        foreach (var apiKey in Fixture.ApiKeys)
        {
            //apiKey.ValidateScopes(requiredPermissions);
            var service = new ShippingAndFulfillmentService(apiKey.MyShopifyUrl, apiKey.AccessToken);
            var request = new FulfillmentServiceItem()
            {
                FulfillmentService = new FulfillmentService()
                {
                    Name = name, 
                    Email = email, 
                    Format = FulfillmentServiceFormat.json
                }
            };
            var created = await service.FulfillmentService.CreateNewFulfillmentServiceAsync(request, CancellationToken.None);
            _additionalPropertiesHelper.CheckAdditionalProperties(created, apiKey.MyShopifyUrl);

            Assert.Equal(name, created.FulfillmentService?.Name);
            Assert.NotNull(created.FulfillmentService?.Id);
            Debug.Assert(created.FulfillmentService != null, "created.TestFulfillmentServices != null");
            apiKey.TestFulfillmentServices.Add(created.FulfillmentService);
        }
    }

    /// <summary>
    /// Ensure that the created fulfillment service can be returned
    /// </summary>
    [Fact, TestPriority(2)]
    public async void ReceiveSingleFulfillmentServiceAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        foreach (var apiKey in Fixture.ApiKeys)
        {
            Assert.NotNull(apiKey.TestFulfillmentServices.First().Id);
            if (apiKey.TestFulfillmentServices.First() is not { Handle: { } }) return;
            var testFulfillmentService = apiKey.TestFulfillmentServices.First();
            var service = new ShippingAndFulfillmentService(apiKey.MyShopifyUrl, apiKey.AccessToken);

            var single =
                await service.FulfillmentService.ReceiveSingleFulfillmentServiceAsync(testFulfillmentService.Id ?? 0,
                    CancellationToken.None);
            _additionalPropertiesHelper.CheckAdditionalProperties(single, apiKey.MyShopifyUrl);

            Assert.NotNull(single.FulfillmentService?.Id);
            Assert.Equal(testFulfillmentService.Handle, single.FulfillmentService?.Handle);
        }
    }

    [Fact, TestPriority(2)]
    public async void ReceiveListOfAllFulfillmentServicesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var requiredPermissions = new List<AuthorizationScope> { AuthorizationScope.read_reports };
        foreach (var apiKey in Fixture.ApiKeys)
        {
            //apiKey.ValidateScopes(requiredPermissions);
            var service = new ShippingAndFulfillmentService(apiKey.MyShopifyUrl, apiKey.AccessToken);
            var result = await service.FulfillmentService.ReceiveListOfAllFulfillmentServicesAsync(FulfillmentServiceScope.current_client);
            _additionalPropertiesHelper.CheckAdditionalProperties(result, apiKey.MyShopifyUrl);

            if (result.FulfillmentServices != null && !result.FulfillmentServices.Any())
            {
                Skip.If(result.FulfillmentServices == null || !result.FulfillmentServices.Any(),
                    "WARN: No data returned. Could not test");
                return;
            }

            foreach (var token in result.FulfillmentServices!)
            {
                _additionalPropertiesHelper.CheckAdditionalProperties(token, apiKey.MyShopifyUrl);
            }

            Assert.NotEmpty(result.FulfillmentServices);
            apiKey.TestFulfillmentServices.AddRange(result.FulfillmentServices.Where(fs => !apiKey.TestFulfillmentServices.Exists(e => e.Id == fs.Id) && fs.Name.StartsWith(FulfillmentServicePrefix)));
        }
    }
    /// <summary>
    /// update the newly created fulfillment service
    /// </summary>
    [Fact, TestPriority(3)]
    public async void ModifyExistingFulfillmentServiceAsync_CanUpdate()
    {
        foreach (var apiKey in Fixture.ApiKeys)
        {
            var testFulfillmentService = apiKey.TestFulfillmentServices.First();
            Assert.NotNull(testFulfillmentService.Id);
            if (testFulfillmentService is not { Handle: { } }) return;
            var service = new ShippingAndFulfillmentService(apiKey.MyShopifyUrl, apiKey.AccessToken);

            var updateRequest = new FulfillmentServiceItem() { FulfillmentService = testFulfillmentService };
            updateRequest.FulfillmentService!.Email = @"open@sample.com";
            var updated =
                await service.FulfillmentService.ModifyExistingFulfillmentServiceAsync(updateRequest.FulfillmentService.Id ?? 0, updateRequest,
                    CancellationToken.None);
            _additionalPropertiesHelper.CheckAdditionalProperties(updated, apiKey.MyShopifyUrl);

            Assert.NotNull(updated.FulfillmentService?.Id);
            Assert.Equal(testFulfillmentService.Id, updated.FulfillmentService?.Id);
        }
    }
    [Fact, TestPriority(4)]
    public async void RemoveExistingFulfillmentServiceAsync_CanDelete()
    {
        foreach (var apiKey in Fixture.ApiKeys)
        {
            var service = new ShippingAndFulfillmentService(apiKey.MyShopifyUrl, apiKey.AccessToken);
            foreach (var testFulfillmentService in apiKey.TestFulfillmentServices)
            {
                await service.FulfillmentService.RemoveExistingFulfillmentServiceAsync(testFulfillmentService.Id ?? 0, CancellationToken.None);
            }
        }
    }
}
