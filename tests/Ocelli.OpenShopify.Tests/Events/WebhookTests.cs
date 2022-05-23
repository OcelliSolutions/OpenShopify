using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Events;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class WebhookTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly EventsService _service;

    public WebhookTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new EventsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountWebhooksAsync_CanGet()
    {
        var response = await _service.Webhook.CountWebhooksAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Assert.True(count > 0);
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListWebhooksAsync_AdditionalPropertiesIsEmpty()
    {
        var response = await _service.Webhook.ListWebhooksAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var webhook in response.Result.Webhooks)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(webhook, Fixture.MyShopifyUrl);
        }
        var list = response.Result.Webhooks;
        Assert.True(list.Any());
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetWebhookAsync_AdditionalPropertiesIsEmpty()
    {
        var webhookListResponse = await _service.Webhook.ListWebhooksAsync(limit: 1);
        var response = await _service.Webhook.GetWebhookAsync(webhookListResponse.Result.Webhooks.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Webhook, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}
