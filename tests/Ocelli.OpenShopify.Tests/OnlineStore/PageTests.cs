﻿namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class PageFixture : SharedFixture, IAsyncLifetime
{
    public PageFixture() =>
        Service = new OnlineStoreService(MyShopifyUrl, AccessToken);

    public IOnlineStoreService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class PageTests : IClassFixture<PageFixture>
{
    private PageFixture Fixture { get; }
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly PageMockClient _badRequestMockClient;
    private readonly PageMockClient _okEmptyMockClient;
    private readonly PageMockClient _okInvalidJsonMockClient;

    public PageTests(PageFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new PageMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new PageMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new PageMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }


    #region Create

    #endregion Create

    #region Read

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete

    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class PageMockClient : PageClient, IMockTests
{
    public PageMockClient(HttpClient httpClient, PageFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}

