using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Plus;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class UserTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly PlusService _service;

    public UserTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new PlusService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create

    #endregion Create

    #region Read
    
    [SkippableFact(Skip = "Must be tested on a plus store"), TestPriority(20)]
    public async Task ListUsersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.User.ListUsersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var user in response.Result.Users)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(user, Fixture.MyShopifyUrl);
        }
        var list = response.Result.Users;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact(Skip = "Must be tested on a plus store"), TestPriority(20)]
    public async Task GetUserAsync_AdditionalPropertiesAreEmpty()
    {
        var userListResponse = await _service.User.ListUsersAsync(limit: 1);
        Skip.If(!userListResponse.Result.Users.Any(), "No results returned. Unable to test");
        var response = await _service.User.GetUserAsync(userListResponse.Result.Users.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.User, Fixture.MyShopifyUrl);
    }

    [SkippableFact(Skip = "Must be tested on a plus store"), TestPriority(20)]
    public async Task GetCurrentlyLoggedInUserAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.User.GetCurrentlyLoggedInUserAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.User, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}