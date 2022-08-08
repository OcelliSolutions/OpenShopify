namespace Ocelli.OpenShopify.Tests.Plus;

public class UserFixture : SharedFixture, IAsyncLifetime
{
    public List<User> CreatedUsers = new();
    public IPlusService Service;

    public UserFixture() =>
        Service = new PlusService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("UserTests")]
public class UserTests : IClassFixture<UserFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly UserMockClient _badRequestMockClient;
    private readonly UserMockClient _okEmptyMockClient;
    private readonly UserMockClient _okInvalidJsonMockClient;

    public UserTests(UserFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new UserMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new UserMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new UserMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
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


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class UserMockClient : UserClient, IMockTests
{
    public UserMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        Skip.If(0==1,"Not implemented.");
        return Task.CompletedTask;
    }
}
