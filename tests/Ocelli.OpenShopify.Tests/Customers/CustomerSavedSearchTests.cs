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
            _ = await Service.CustomerSavedSearch.DeleteCustomerSavedSearchAsync(customerSavedSearch.Id, CancellationToken.None);
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
                Name = $@"This Name Has Been Changed: {Fixture.BatchId}"
            }
        };
        var response =
            await Fixture.Service.CustomerSavedSearch.UpdateCustomerSavedSearchAsync(request.CustomerSavedSearch.Id,
                request, CancellationToken.None);
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
        var response = await Fixture.Service.CustomerSavedSearch.CreateCustomerSavedSearchAsync(request, CancellationToken.None);
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
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.CustomerSavedSearch.CreateCustomerSavedSearchAsync(request, CancellationToken.None));
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
        var response = await Fixture.Service.CustomerSavedSearch.ListCustomerSavedSearchesAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var customerSavedSearch in response.Result.CustomerSavedSearches)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(customerSavedSearch, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.CustomerSavedSearches.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetCustomerSavedSearchAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCustomerSavedSearches.Any(), "Must be run with create test");
        var customerSavedSearch = Fixture.CreatedCustomerSavedSearches.First();
        var response = await Fixture.Service.CustomerSavedSearch.GetCustomerSavedSearchAsync(customerSavedSearch.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerSavedSearch,
            Fixture.MyShopifyUrl);
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class CustomerSavedSearchMockClient : CustomerSavedSearchClient, IMockTests
{
    public CustomerSavedSearchMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListCustomerSavedSearchesAsync(cancellationToken: CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListCustomerSavedSearchesAsync(cancellationToken: CancellationToken.None));
    }
}
