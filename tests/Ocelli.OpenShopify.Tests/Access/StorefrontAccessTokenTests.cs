namespace Ocelli.OpenShopify.Tests.Access;

public class StorefrontAccessTokenFixture : SharedFixture, IAsyncLifetime
{
    public List<StorefrontAccessToken> CreatedStorefrontAccessTokens = new();
    public AccessService Service;

    public StorefrontAccessTokenFixture() => Service = new AccessService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteStorefrontAccessTokenAsync_CanDelete();

    public async Task DeleteStorefrontAccessTokenAsync_CanDelete()
    {
        foreach (var webhook in CreatedStorefrontAccessTokens)
        {
            _ = await Service.StorefrontAccess.DeleteStorefrontAccessTokenAsync(webhook.Id, CancellationToken.None);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("StorefrontAccessTokenTests")]
public class StorefrontAccessTokenTests : IClassFixture<StorefrontAccessTokenFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly StorefrontAccessTokenMockClient _badRequestMockClient;
    private readonly StorefrontAccessTokenMockClient _okEmptyMockClient;
    private readonly StorefrontAccessTokenMockClient _okInvalidJsonMockClient;

    public StorefrontAccessTokenTests(StorefrontAccessTokenFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new StorefrontAccessTokenMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new StorefrontAccessTokenMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new StorefrontAccessTokenMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private StorefrontAccessTokenFixture Fixture { get; }

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateStorefrontAccessTokenAsync_CanCreate()
    {
        var request = new CreateStorefrontAccessTokenRequest
        {
            StorefrontAccessToken = new CreateStorefrontAccessToken
            {
                Title = $@"{Fixture.Company} StorefrontAccessToken {Fixture.BatchId}"
            }
        };
        var response = await Fixture.Service.StorefrontAccess.CreateStorefrontAccessTokenAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedStorefrontAccessTokens.Add(response.Result.StorefrontAccessToken);
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListStorefrontAccessTokensThatHaveBeenIssuedAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var requiredPermissions = new List<AuthorizationScope>
        {
            AuthorizationScope.ReadProducts,
            AuthorizationScope.WriteProducts,
            AuthorizationScope.UnauthenticatedReadContent,
            AuthorizationScope.UnauthenticatedReadCustomerTags,
            AuthorizationScope.UnauthenticatedReadProductTags,
            AuthorizationScope.UnauthenticatedReadProductListings,
            AuthorizationScope.UnauthenticatedWriteCheckouts,
            AuthorizationScope.UnauthenticatedReadCheckouts,
            AuthorizationScope.UnauthenticatedWriteCustomers,
            AuthorizationScope.UnauthenticatedReadCustomers
        };
        Fixture.ValidateScopes(requiredPermissions);
        var response = await Fixture.Service.StorefrontAccess.ListStorefrontAccessTokensThatHaveBeenIssuedAsync(CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Skip.If(!response.Result.StorefrontAccessTokens.Any(), "WARN: No data returned. Could not test");

        foreach (var token in response.Result.StorefrontAccessTokens)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteStorefrontAccessTokenAsync_CanDelete()
    {
        foreach (var webhook in Fixture.CreatedStorefrontAccessTokens)
        {
            _ = await Fixture.Service.StorefrontAccess.DeleteStorefrontAccessTokenAsync(webhook.Id, CancellationToken.None);
        }

        Fixture.CreatedStorefrontAccessTokens.Clear();
    }

    #endregion Delete

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class StorefrontAccessTokenMockClient : StorefrontAccessTokenClient, IMockTests
{
    public StorefrontAccessTokenMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListStorefrontAccessTokensThatHaveBeenIssuedAsync(CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListStorefrontAccessTokensThatHaveBeenIssuedAsync(CancellationToken.None));
    }
}
