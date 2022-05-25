using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Access;

public class StorefrontAccessTokenFixture : SharedFixture, IAsyncLifetime
{
    public List<StorefrontAccessToken> CreatedStorefrontAccessTokens = new();
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class StorefrontAccessTokenTests : IClassFixture<StorefrontAccessTokenFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly AccessService _service;
    private readonly ITestOutputHelper _testOutputHelper;

    public StorefrontAccessTokenTests(ITestOutputHelper testOutputHelper, StorefrontAccessTokenFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new AccessService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private StorefrontAccessTokenFixture Fixture { get; }

    [SkippableFact]
    public async Task
        ListStorefrontAccessTokensThatHaveBeenIssuedAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var requiredPermissions = new List<AuthorizationScope>
        {
            AuthorizationScope.read_products,
            AuthorizationScope.write_products,
            AuthorizationScope.unauthenticated_read_content,
            AuthorizationScope.unauthenticated_read_customer_tags,
            AuthorizationScope.unauthenticated_read_product_tags,
            AuthorizationScope.unauthenticated_read_product_listings,
            AuthorizationScope.unauthenticated_write_checkouts,
            AuthorizationScope.unauthenticated_read_checkouts,
            AuthorizationScope.unauthenticated_write_customers,
            AuthorizationScope.unauthenticated_read_customers
        };
        Fixture.ValidateScopes(requiredPermissions);
        var response = await _service.StorefrontAccess.ListStorefrontAccessTokensThatHaveBeenIssuedAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Skip.If(!response.Result.StorefrontAccessTokens.Any(), "WARN: No data returned. Could not test");

        foreach (var token in response.Result.StorefrontAccessTokens)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }
    }
}