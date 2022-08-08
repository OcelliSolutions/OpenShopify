namespace Ocelli.OpenShopify.Tests.Customers;

public class CustomerFixture : SharedFixture, IAsyncLifetime
{
    public List<Customer> CreatedCustomers = new();
    public ICustomersService Service;

    public CustomerFixture() =>
        Service = new CustomersService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteCustomerAsync_CanDelete();

    public async Task DeleteCustomerAsync_CanDelete()
    {
        foreach (var customer in CreatedCustomers)
        {
            _ = await Service.Customer.DeleteCustomerAsync(customer.Id);
        }

        CreatedCustomers.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("CustomerTests")]
public class CustomerTests : IClassFixture<CustomerFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CustomerMockClient _badRequestMockClient;
    private readonly CustomerMockClient _okEmptyMockClient;
    private readonly CustomerMockClient _okInvalidJsonMockClient;

    public CustomerTests(CustomerFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CustomerMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CustomerMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CustomerMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CustomerFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateCustomerAsync_CanUpdate()
    {
        var originalCustomer = Fixture.CreatedCustomers.First();
        var request = new UpdateCustomerRequest
        {
            Customer = new UpdateCustomer
            {
                Id = originalCustomer.Id,
                Note = $@"{originalCustomer.Note} | Customer is a great guy"
            }
        };
        var response = await Fixture.Service.Customer.UpdateCustomerAsync(request.Customer.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomers.Remove(originalCustomer);
        Fixture.CreatedCustomers.Add(response.Result.Customer);
    }

    #endregion Update

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteCustomerAsync_CanDelete() => await Fixture.DeleteCustomerAsync_CanDelete();

    #endregion Delete

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCustomerAsync_CanCreate()
    {
        var request = Fixture.CreateCustomerRequest();
        var response = await Fixture.Service.Customer.CreateCustomerAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomers.Add(response.Result.Customer);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCustomerAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCustomerRequest
        {
            Customer = new CreateCustomer()
        };
        await Assert.ThrowsAsync<ApiException<CustomerError>>(async () =>
            await Fixture.Service.Customer.CreateCustomerAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountCustomersAsync_CanGet()
    {
        var response = await Fixture.Service.Customer.CountCustomersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCustomersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Customer.ListCustomersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var customer in response.Result.Customers)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(customer, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Customers.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetCustomerAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "Must be run with create test");
        var customer = Fixture.CreatedCustomers.First();
        var response = await Fixture.Service.Customer.GetCustomerAsync(customer.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Customer, Fixture.MyShopifyUrl);
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class CustomerMockClient : CustomerClient, IMockTests
{
    public CustomerMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnData()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListCustomersAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListCustomersAsync());
    }
}
