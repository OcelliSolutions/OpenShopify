﻿namespace Ocelli.OpenShopify.Tests.Customers;

public class CustomerAddressFixture : SharedFixture, IAsyncLifetime
{
    public List<CustomerAddress> CreatedCustomerAddresses = new();
    public Customer Customer = new();
    public ICustomersService Service;

    public CustomerAddressFixture() =>
        Service = new CustomersService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync() => await CreateCustomer();

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteCustomerAddressAsync_CanDelete();

        if (Customer.Id > 0)
        {
            await Service.Customer.DeleteCustomerAsync(Customer.Id);
        }
    }

    public async Task DeleteCustomerAddressAsync_CanDelete()
    {
        foreach (var customerAddress in CreatedCustomerAddresses)
        {
            _ = await Service.CustomerAddress.DeleteAddressFromCustomersAddressListAsync(customerAddress.Id,
                Customer.Id, CancellationToken.None);
        }

        CreatedCustomerAddresses.Clear();
    }

    public async Task CreateCustomer()
    {
        var request = CreateCustomerRequest();
        var response = await Service.Customer.CreateCustomerAsync(request);
        Customer = response.Result.Customer;
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("CustomerAddressTests")]
public class CustomerAddressTests : IClassFixture<CustomerAddressFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CustomerAddressMockClient _badRequestMockClient;
    private readonly CustomerAddressMockClient _okEmptyMockClient;
    private readonly CustomerAddressMockClient _okInvalidJsonMockClient;

    public CustomerAddressTests(CustomerAddressFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CustomerAddressMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CustomerAddressMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CustomerAddressMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CustomerAddressFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateCustomerAddressAsync_CanUpdate()
    {
        var originalCustomerAddress = Fixture.CreatedCustomerAddresses.First();
        var request = new UpdateCustomerAddressRequest
        {
            CustomerAddress = new UpdateCustomerAddress
            {
                Id = originalCustomerAddress.Id,
                Zip = "90210"
            }
        };
        var response =
            await Fixture.Service.CustomerAddress.UpdateCustomerAddressAsync(request.CustomerAddress.Id,
                Fixture.Customer.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomerAddresses.Remove(originalCustomerAddress);
        Fixture.CreatedCustomerAddresses.Add(response.Result.CustomerAddress);
    }

    #endregion Update
    
    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCustomerAddressAsync_CanCreate()
    {
        var request = Fixture.CreateAddressForCustomerRequest();
        var response =
            await Fixture.Service.CustomerAddress.CreateAddressForCustomerAsync(Fixture.Customer.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomerAddresses.Add(response.Result.CustomerAddress);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCustomerAddressAsync_IsUnprocessableEntityError()
    {
        var request = new CreateAddressForCustomerRequest()
        {
            CustomerAddress = new CreateCustomerAddress()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.CustomerAddress.CreateAddressForCustomerAsync(Fixture.Customer.Id, request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCustomerAddressesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.CustomerAddress.ListAddressesForCustomerAsync(Fixture.Customer.Id, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var customerAddress in response.Result.Addresses)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(customerAddress, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Addresses.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetCustomerAddressAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCustomerAddresses.Any(), "Must be run with create test");
        var customerAddress = Fixture.CreatedCustomerAddresses.First();
        var response =
            await Fixture.Service.CustomerAddress.GetCustomerAddressAsync(customerAddress.Id, Fixture.Customer.Id, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);
    }

    #endregion Read


    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteCustomerAddressAsync_CanDelete() => await Fixture.DeleteCustomerAddressAsync_CanDelete();

    #endregion Delete


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class CustomerAddressMockClient : CustomerAddressClient, IMockTests
{
    public CustomerAddressMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListAddressesForCustomerAsync(0, CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListAddressesForCustomerAsync(0, CancellationToken.None));
    }
}
