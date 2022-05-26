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
    public AccessService Service;

    public StorefrontAccessTokenFixture() => Service = new AccessService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteStorefrontAccessTokenAsync_CanDelete();

    public async Task DeleteStorefrontAccessTokenAsync_CanDelete()
    {
        foreach (var webhook in CreatedStorefrontAccessTokens)
        {
            _ = await Service.StorefrontAccess.DeleteStorefrontAccessTokenAsync(webhook.Id);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class StorefrontAccessTokenTests : IClassFixture<StorefrontAccessTokenFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;


    public StorefrontAccessTokenTests(StorefrontAccessTokenFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
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
        var response = await Fixture.Service.StorefrontAccess.CreateStorefrontAccessTokenAsync(request);
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
        var response = await Fixture.Service.StorefrontAccess.ListStorefrontAccessTokensThatHaveBeenIssuedAsync();
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
            _ = await Fixture.Service.StorefrontAccess.DeleteStorefrontAccessTokenAsync(webhook.Id);
        }

        Fixture.CreatedStorefrontAccessTokens.Clear();
    }

    #endregion Delete
}