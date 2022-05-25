using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Events;

public class WebhookFixture : SharedFixture, IAsyncLifetime
{
    public List<Webhook> CreatedWebhooks = new();
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class WebhookTests : IClassFixture<WebhookFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly EventsService _service;
    private const string Domain = "sample.com";
    public WebhookTests(ITestOutputHelper testOutputHelper, WebhookFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new EventsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private WebhookFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateWebhookAsync_CanCreate()
    {
        var request = new CreateWebhookRequest()
        {
            Webhook = new()
            {
                Topic = WebhookTopic.fulfillment_events_create, 
                Address = $@"https://{Domain}/api/webhook/fulfillment_events_create"
            }
        };
        var response = await _service.Webhook.CreateWebhookAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedWebhooks.Add(response.Result.Webhook);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateWebhookAsync_IsUnprocessableEntityError()
    {
        var request = new CreateWebhookRequest()
        {
            Webhook = new()
            {
                Topic = WebhookTopic.app_uninstalled
            }
        };
        await Assert.ThrowsAsync<ApiException<WebhookError>>(async () => await _service.Webhook.CreateWebhookAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountWebhooksAsync_CanGet()
    {
        var response = await _service.Webhook.CountWebhooksAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListWebhooksAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.Webhook.ListWebhooksAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var webhook in response.Result.Webhooks)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(webhook, Fixture.MyShopifyUrl);
            if (webhook.Address != null && webhook.Address.Contains(Domain)
                                        && !Fixture.CreatedWebhooks.Exists(w => w.Id == webhook.Id))
                Fixture.CreatedWebhooks.Add(webhook);
        }
        var list = response.Result.Webhooks;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetWebhookAsync_AdditionalPropertiesAreEmpty()
    {
        var webhookListResponse = await _service.Webhook.ListWebhooksAsync(limit: 1);
        Skip.If(!webhookListResponse.Result.Webhooks.Any(), "No results returned. Unable to test");
        var response = await _service.Webhook.GetWebhookAsync(webhookListResponse.Result.Webhooks.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Webhook, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetWebhookAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedWebhooks.Any(), "No results returned. Unable to test");
        var webhook = Fixture.CreatedWebhooks.First();
        var response = await _service.Webhook.GetWebhookAsync(webhook.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Webhook, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateWebhookAsync_CanUpdate()
    {
        var originalWebhook = Fixture.CreatedWebhooks.First();
        var request = new UpdateWebhookRequest()
        {
            Webhook = new()
            {
                Id = originalWebhook.Id, 
                Fields = new List<string>(){"id"}
            }
        };
        var response = await _service.Webhook.UpdateWebhookAsync(request.Webhook.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedWebhooks.Remove(originalWebhook);
        Fixture.CreatedWebhooks.Add(response.Result.Webhook);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(40)]
    public async Task DeleteWebhookAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedWebhooks.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var webhook in Fixture.CreatedWebhooks)
        {
            try
            {
                _ = await _service.Webhook.DeleteWebhookAsync(webhook.Id);
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }
        }

        foreach (var error in errors)
        {
            _testOutputHelper.WriteLine(error.Message);
        }
        Assert.Empty(errors);
    }
    #endregion Delete
}
