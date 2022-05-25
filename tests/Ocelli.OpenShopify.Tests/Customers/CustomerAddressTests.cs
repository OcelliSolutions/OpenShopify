using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Customers;

public class CustomerAddressFixture : SharedFixture, IAsyncLifetime
{
    public List<Address> CreatedAddresses = new();
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CustomerAddressTests : IClassFixture<CustomerAddressFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CustomersService _service;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public CustomerAddressTests(ITestOutputHelper testOutputHelper, CustomerAddressFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new CustomersService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private CustomerAddressFixture Fixture { get; }

    #region Create
    [SkippableFact, TestPriority(10)]
    public async Task Creates_Addresses()
    {
        var createCustomerRequest = Fixture.CreateCustomerRequest;
        var customerResponse = await _service.Customer.CreateCustomerAsync(createCustomerRequest);
        var customer = customerResponse.Result.Customer;

        var request = new CreateCustomerAddressRequest
        {
            CustomerAddress = new()
            {
                Address1 = Fixture.BatchId,
                City = "Minneapolis",
                Province = "Minnesota",
                ProvinceCode = "MN",
                Zip = "55401",
                Phone = "555-555-5555",
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Company = customer.DefaultAddress?.Company,
                Country = "United States",
                CountryCode = "US",
                Default = true,
            }
        };
        var response = await _service.CustomerAddress.CreateAddressForCustomerAsync(customer.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);

        var created = response.Result.CustomerAddress;
        Assert.NotNull(created);
        Assert.Equal(Fixture.BatchId, created.Address1);
        Assert.Equal(customer.FirstName, created.FirstName);
        Assert.Equal(customer.LastName, created.LastName);

        var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerAddress, Address>());
        var mapper = new Mapper(config);
        var address = mapper.Map<Address>(created);
        Fixture.CreatedAddresses.Add(address);
    }
    #endregion Create

    #region Read
    [SkippableFact, TestPriority(20)]
    public async Task Lists_Addresses()
    {
        Skip.If(!Fixture.CreatedAddresses.Any(), "A customer must be created with the CustomerTests first. Run in parallel.");
        var address = Fixture.CreatedAddresses.First();
        var response = await _service.CustomerAddress.ListAddressesForCustomerAsync(address.CustomerId ?? 0);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var resultAddress in response.Result.Addresses)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(resultAddress, Fixture.MyShopifyUrl);
        }

        Assert.True(response.Result.Addresses.Count > 0);

        //Add any created items from previously failed tests to the created list for later deletion.
        Fixture.CreatedAddresses.AddRange(response.Result.Addresses.Where(fs =>
            !Fixture.CreatedAddresses.Exists(e => e.Id == fs.Id) &&
            fs.FirstName!.StartsWith(Fixture.FirstName)));
    }

    [SkippableFact, TestPriority(20)]
    public async Task Gets_Addresses()
    {
        Skip.If(!Fixture.CreatedAddresses.Any(), "A customer must be created with the CustomerTests first. Run in parallel.");
        var createdAddress = Fixture.CreatedAddresses.First();
        var response =
            await _service.CustomerAddress.GetCustomerAddressAsync(
                createdAddress.Id, createdAddress.CustomerId ?? 0);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);

        var address = response.Result.CustomerAddress;
        Assert.NotNull(address);
        Assert.Equal(Fixture.BatchId, address.Address1);
        Assert.Equal(createdAddress.FirstName, address.FirstName);
        Assert.Equal(createdAddress.LastName, address.LastName);
    }
    #endregion Read

    #region Update
    [SkippableFact, TestPriority(30)]
    public async Task Updates_Addresses()
    {
        Skip.If(!Fixture.CreatedAddresses.Any(), "A customer must be created with the CustomerTests first. Run in parallel.");
        var createdAddress = Fixture.CreatedAddresses.First();
        var request = new UpdateCustomerAddressRequest()
        {
            CustomerAddress = new()
            {
                Id = createdAddress.Id,
                LastName = Fixture.BatchId
            }
        };
        var response =
            await _service.CustomerAddress.UpdateCustomerAddressAsync(createdAddress.Id, 
                createdAddress.CustomerId ?? 0, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);
        
        Assert.Equal(Fixture.BatchId, response.Result.CustomerAddress.LastName);

        // Reset the id so the Fixture can properly delete this object.
        Fixture.CreatedAddresses.Remove(createdAddress);

        var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerAddress, Address>());
        var mapper = new Mapper(config);
        var address = mapper.Map<Address>(response.Result.CustomerAddress);
        Fixture.CreatedAddresses.Add(address);
    }
    #endregion Update

    #region Delete
    [SkippableFact, TestPriority(40)]
    public async Task Deletes_Addresses()
    {
        //Cannot delete the customer’s default address
        var deletableAddresses = Fixture.CreatedAddresses.Where(a => !a.Default ?? false).ToList();
        Skip.If(!deletableAddresses.Any(), "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var address in deletableAddresses)
        {
            try
            {
                await _service.CustomerAddress.DeleteAddressFromCustomersAddressListAsync(
                        address.Id, address.CustomerId ?? 0);
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }
        }

        foreach (var error in errors)
        {
            _testOutputHelper.WriteLine(error.Message);
        }
        Assert.Empty(errors);
    }
    #endregion Delete
}
