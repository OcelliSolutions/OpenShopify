using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Customers;

public class CustomerAddressFixture : SharedFixture, IAsyncLifetime
{
    public List<CustomerAddress> CreatedCustomerAddresses = new();
    public Customer Customer = new();
    public CustomersService Service;

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
                Customer.Id);
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
public class CustomerAddressTests : IClassFixture<CustomerAddressFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public CustomerAddressTests(CustomerAddressFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
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
                Fixture.Customer.Id, request);
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
        var request = Fixture.CreateCustomerAddressRequest();
        var response =
            await Fixture.Service.CustomerAddress.CreateAddressForCustomerAsync(Fixture.Customer.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomerAddresses.Add(response.Result.CustomerAddress);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCustomerAddressAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCustomerAddressRequest
        {
            CustomerAddress = new CreateCustomerAddress()
        };
        await Assert.ThrowsAsync<ApiException<CustomerAddressError>>(async () =>
            await Fixture.Service.CustomerAddress.CreateAddressForCustomerAsync(Fixture.Customer.Id, request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCustomerAddressesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.CustomerAddress.ListAddressesForCustomerAsync(Fixture.Customer.Id);
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
            await Fixture.Service.CustomerAddress.GetCustomerAddressAsync(customerAddress.Id, Fixture.Customer.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);
    }

    #endregion Read


    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteCustomerAddressAsync_CanDelete() => await Fixture.DeleteCustomerAddressAsync_CanDelete();

    #endregion Delete
}