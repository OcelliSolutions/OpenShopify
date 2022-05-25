using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Access;

public class AccessScopeFixture : SharedFixture, IAsyncLifetime
{
    public List<AccessScope> CreatedAccessScopes = new();
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class AccessScopeTests : IClassFixture<AccessScopeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly AccessService _service;

    public AccessScopeTests(ITestOutputHelper testOutputHelper, AccessScopeFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new AccessService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private AccessScopeFixture Fixture { get; }

    [SkippableFact]
    public async Task ListAccessScopesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var result = await _service.AccessScope.ListAccessScopesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        if (result.Result.AccessScopes == null)
        {
            Skip.If(result.Result.AccessScopes == null || !result.Result.AccessScopes.Any(),
                "WARN: No data returned. Could not test");
            return;
        }

        foreach (var accessScope in result.Result.AccessScopes)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(accessScope, Fixture.MyShopifyUrl);
        }

        Assert.NotEmpty(result.Result.AccessScopes);
        var handles = result.Result.AccessScopes.Select(a => a.Handle!);
        Assert.Contains(AuthorizationScope.read_orders, handles);
    }

    [SkippableFact]
    public async Task ListAccessScopesAsync_InvalidCredentials_ShouldFail()
    {
        var service = new AccessService("invalid", "invalid");
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
            await service.AccessScope.ListAccessScopesAsync());
    }
}