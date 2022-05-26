using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Plus;

public class UserFixture : SharedFixture, IAsyncLifetime
{
    public List<User> CreatedUsers = new();
    public PlusService Service;

    public UserFixture() =>
        Service = new PlusService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class UserTests : IClassFixture<UserFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;


    public UserTests(UserFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private UserFixture Fixture { get; }

    #region Read

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(20)]
    public async Task ListUsersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.User.ListUsersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var user in response.Result.Users)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(user, Fixture.MyShopifyUrl);
        }

        var list = response.Result.Users;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(20)]
    public async Task GetUserAsync_AdditionalPropertiesAreEmpty()
    {
        var userListResponse = await Fixture.Service.User.ListUsersAsync(1);
        Skip.If(!userListResponse.Result.Users.Any(), "No results returned. Unable to test");
        var response = await Fixture.Service.User.GetUserAsync(userListResponse.Result.Users.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.User, Fixture.MyShopifyUrl);
    }

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(20)]
    public async Task GetCurrentlyLoggedInUserAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.User.GetCurrentlyLoggedInUserAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.User, Fixture.MyShopifyUrl);
    }

    #endregion Read
}