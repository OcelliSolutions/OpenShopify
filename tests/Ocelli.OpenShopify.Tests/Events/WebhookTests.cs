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
    public EventsService Service;
    public List<Webhook> CreatedWebhooks = new();

    public WebhookFixture()
    {
        Service = new EventsService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteWebhookAsync_CanDelete();
    }

    public async Task DeleteWebhookAsync_CanDelete()
    {
        foreach (var webhook in CreatedWebhooks)
        {
            _ = await Service.Webhook.DeleteWebhookAsync(webhook.Id);
        }
        CreatedWebhooks.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class WebhookTests : IClassFixture<WebhookFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public WebhookTests(WebhookFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private WebhookFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateWebhookAsync_CanCreate()
    {
        var request = Fixture.CreateWebhookRequest();
        var response = await Fixture.Service.Webhook.CreateWebhookAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedWebhooks.Add(response.Result.Webhook);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateWebhookAsync_IsUnprocessableEntityError()
    {
        var request = new CreateWebhookRequest()
        {
            Webhook = new()
        };
        await Assert.ThrowsAsync<ApiException<WebhookError>>(async () => await Fixture.Service.Webhook.CreateWebhookAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountWebhooksAsync_CanGet()
    {
        var response = await Fixture.Service.Webhook.CountWebhooksAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListWebhooksAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Webhook.ListWebhooksAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var webhook in response.Result.Webhooks)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(webhook, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.Webhooks.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetWebhookAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedWebhooks.Any(), "Must be run with create test");
        var webhook = Fixture.CreatedWebhooks.First();
        var response = await Fixture.Service.Webhook.GetWebhookAsync(webhook.Id);
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
                Fields = new List<string>{"id"}
            }
        };
        var response = await Fixture.Service.Webhook.UpdateWebhookAsync(originalWebhook.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedWebhooks.Remove(originalWebhook);
        Fixture.CreatedWebhooks.Add(response.Result.Webhook);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteWebhookAsync_CanDelete()
    {
        await Fixture.DeleteWebhookAsync_CanDelete();
    }

    #endregion Delete
    }
