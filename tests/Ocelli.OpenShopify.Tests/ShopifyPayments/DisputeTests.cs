using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShopifyPayments;

public class DisputeFixture : SharedFixture, IAsyncLifetime
{
    public List<Dispute> CreatedDisputes = new();
    public ShopifyPaymentsService Service;

    public DisputeFixture() =>
        Service = new ShopifyPaymentsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class DisputeTests : IClassFixture<DisputeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public DisputeTests(DisputeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private DisputeFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListDisputesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Dispute.ListDisputesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var dispute in response.Result.Disputes)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(dispute, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Disputes.Any(), "No results returned. Unable to test");
        Fixture.CreatedDisputes.AddRange(response.Result.Disputes);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetDisputeAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedDisputes.Any(), "Must be run with the list test");
        var dispute = Fixture.CreatedDisputes.First();
        var response = await Fixture.Service.Dispute.GetDisputeAsync(dispute.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Dispute, Fixture.MyShopifyUrl);
    }

    #endregion Read
}