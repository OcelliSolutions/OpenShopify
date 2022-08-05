namespace Ocelli.OpenShopify.Tests.Customers;

public class CustomerSavedSearchFixture : SharedFixture, IAsyncLifetime
{
    public List<CustomerSavedSearch> CreatedCustomerSavedSearches = new();
    public ICustomersService Service;

    public CustomerSavedSearchFixture() =>
        Service = new CustomersService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteCustomerSavedSearchAsync_CanDelete();

    public async Task DeleteCustomerSavedSearchAsync_CanDelete()
    {
        foreach (var customerSavedSearch in CreatedCustomerSavedSearches)
        {
            _ = await Service.CustomerSavedSearch.DeleteCustomerSavedSearchAsync(customerSavedSearch.Id);
        }

        CreatedCustomerSavedSearches.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("CustomerSavedSearchTests")]
public class CustomerSavedSearchTests : IClassFixture<CustomerSavedSearchFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CustomerSavedSearchMockClient _badRequestMockClient;
    private readonly CustomerSavedSearchMockClient _okEmptyMockClient;
    private readonly CustomerSavedSearchMockClient _okInvalidJsonMockClient;

    public CustomerSavedSearchTests(CustomerSavedSearchFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CustomerSavedSearchMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CustomerSavedSearchMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CustomerSavedSearchMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CustomerSavedSearchFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateCustomerSavedSearchAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedCustomerSavedSearches.Any(), "Must be run with create test");
        var originalCustomerSavedSearch = Fixture.CreatedCustomerSavedSearches.First();
        var request = new UpdateCustomerSavedSearchRequest
        {
            CustomerSavedSearch = new UpdateCustomerSavedSearch
            {
                Id = originalCustomerSavedSearch.Id,
                Name = @"This Name Has Been Changed"
            }
        };
        var response =
            await Fixture.Service.CustomerSavedSearch.UpdateCustomerSavedSearchAsync(request.CustomerSavedSearch.Id,
                request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomerSavedSearches.Remove(originalCustomerSavedSearch);
        Fixture.CreatedCustomerSavedSearches.Add(response.Result.CustomerSavedSearch);
    }

    #endregion Update

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteCustomerSavedSearchAsync_CanDelete() =>
        await Fixture.DeleteCustomerSavedSearchAsync_CanDelete();

    #endregion Delete

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCustomerSavedSearchAsync_CanCreate()
    {
        var request = Fixture.CreateCustomerSavedSearchRequest();
        var response = await Fixture.Service.CustomerSavedSearch.CreateCustomerSavedSearchAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomerSavedSearches.Add(response.Result.CustomerSavedSearch);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCustomerSavedSearchAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCustomerSavedSearchRequest
        {
            CustomerSavedSearch = new CreateCustomerSavedSearch()
        };
        await Assert.ThrowsAsync<ApiException<CustomerSavedSearchError>>(async () =>
            await Fixture.Service.CustomerSavedSearch.CreateCustomerSavedSearchAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountCustomerSavedSearchesAsync_CanGet()
    {
        var response = await Fixture.Service.CustomerSavedSearch.CountCustomerSavedSearchesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCustomerSavedSearchesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.CustomerSavedSearch.ListCustomerSavedSearchesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var customerSavedSearche in response.Result.CustomerSavedSearches)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(customerSavedSearche, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.CustomerSavedSearches.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetCustomerSavedSearchAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCustomerSavedSearches.Any(), "Must be run with create test");
        var customerSavedSearche = Fixture.CreatedCustomerSavedSearches.First();
        var response = await Fixture.Service.CustomerSavedSearch.GetCustomerSavedSearchAsync(customerSavedSearche.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerSavedSearch,
            Fixture.MyShopifyUrl);
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class CustomerSavedSearchMockClient : CustomerSavedSearchClient, IMockTests
{
    public CustomerSavedSearchMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        Skip.If(0==1,"Not implemented.");
        return Task.CompletedTask;
    }
}
