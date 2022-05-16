using System.Linq;
using System.Net.Http;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Access;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class AccessScopeTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public AccessScopeTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    public async void GetListOfAccessScopesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        foreach (var apiKey in Fixture.ApiKeys)
        {
            var service = new AccessService(apiKey.MyShopifyUrl, apiKey.AccessToken);
            var result = await service.AccessScope.GetListOfAccessScopesAsync();
            _additionalPropertiesHelper.CheckAdditionalProperties(result, apiKey.MyShopifyUrl);

            if (result.AccessScopes == null)
            {
                Skip.If(result.AccessScopes == null || !result.AccessScopes.Any(),
                    "WARN: No data returned. Could not test");
                return;
            }

            foreach (var accessScope in result.AccessScopes)
            {
                _additionalPropertiesHelper.CheckAdditionalProperties(accessScope, apiKey.MyShopifyUrl);
            }

            Assert.NotEmpty(result.AccessScopes);
            var handles = result.AccessScopes.Select(a => a.Handle!);
            Assert.Contains(AuthorizationScope.read_orders, handles);
        }
    }
    [Fact]
    public async void GetListOfAccessScopesAsync_InvalidCredentials_ShouldFail()
    {
        var service = new AccessService("invalid", "sample");
        await Assert.ThrowsAsync<HttpRequestException>(async () => await service.AccessScope.GetListOfAccessScopesAsync());
    }
}
