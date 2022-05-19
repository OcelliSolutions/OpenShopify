using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Access;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class StorefrontAccessTokenTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public StorefrontAccessTokenTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }
    /*
    [SkippableFact]
    public async Task
        RetrieveListOfStorefrontAccessTokensThatHaveBeenIssuedAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var requiredPermissions = new List<AuthorizationScope>()
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
        var service = new AccessService(Fixture.MyShopifyUrl, Fixture.AccessToken);
        var result = await service.StorefrontAccess.RetrieveListOfStorefrontAccessTokensThatHaveBeenIssuedAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        if (result.StorefrontAccessTokens == null)
        {
            Skip.If(result.StorefrontAccessTokens == null || !result.StorefrontAccessTokens.Any(),
                "WARN: No data returned. Could not test");
            return;
        }

        foreach (var token in result.StorefrontAccessTokens)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }

        Assert.NotEmpty(result.StorefrontAccessTokens);
    }
    */
}
