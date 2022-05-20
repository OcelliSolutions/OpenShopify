using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Customers;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CustomerAddressTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CustomersService _service;
    private readonly ITestOutputHelper _testOutputHelper;
    private static string FirstName => "John (OpenShopify)";
    private static string LastName => "Doe";
    private static string Company => "OpenShopify";
    private static string Note => "Test note about this customer.";

    /// <summary>
    /// Customer Address tests should be run in conjunction with Address tests.
    /// The priority number tells the test to run after customer completes.
    /// </summary>
    /// <param name="testOutputHelper"></param>
    /// <param name="sharedFixture"></param>
    public CustomerAddressTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new CustomersService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }
    
    [SkippableFact, TestPriority(10)]
    public async Task Creates_Addresses()
    {
        var customerRequest = new CreateCustomerRequest()
        {
            Customer = new CreateCustomer()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = $@"{Fixture.BatchId}@example.com",
                AcceptsMarketing = false,
                Addresses = new List<CreateAddress>()
                {
                    new()
                    {
                        Address1 = "SAMPLE",
                        City = "Minneapolis",
                        Province = "Minnesota",
                        ProvinceCode = "MN",
                        Zip = "55401",
                        Phone = "555-555-5555",
                        FirstName = FirstName,
                        LastName = LastName,
                        Company = Company,
                        Country = "United States",
                        CountryCode = "US",
                        Default = true,
                    }
                },
                VerifiedEmail = true,
                Note = Note,
                State = "enabled"
            }
        };
        var customerResponse = await _service.Customer.CreateCustomerAsync(customerRequest);
        var customer = customerResponse.Result.Customer;

        if (customer != null)
        {
            Fixture.CreatedCustomers.Add(customer);
        }

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
                FirstName = customer?.FirstName,
                LastName = customer?.LastName,
                Company = Company,
                Country = "United States",
                CountryCode = "US",
                Default = true,
            }
        };
        var response = await _service.CustomerAddress.CreateAddressForCustomerAsync(customer?.Id ?? 0, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);

        var created = response.Result.CustomerAddress;
        Assert.NotNull(created);
        Assert.Equal(Fixture.BatchId, created?.Address1);
        Assert.Equal(customer?.FirstName, created?.FirstName);
        Assert.Equal(customer?.LastName, created?.LastName);
        if (created != null)
        {
            Fixture.CreatedAddresses.Add(created);
        }
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Addresses()
    {
        Skip.If(!Fixture.CreatedAddresses.Any(), "A customer must be created with the CustomerTests first. Run in parallel.");
        var address = Fixture.CreatedAddresses.First();
        var response = await _service.CustomerAddress.ListAddressesForCustomerAsync(address.CustomerId ?? 0);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var resultAddress in response.Result.Addresses!)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(resultAddress, Fixture.MyShopifyUrl);
        }

        Assert.True(response.Result.Addresses?.Count > 0);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Gets_Addresses()
    {
        Skip.If(!Fixture.CreatedAddresses.Any(), "A customer must be created with the CustomerTests first. Run in parallel.");
        var createdAddress = Fixture.CreatedAddresses.First();
        var response =
            await _service.CustomerAddress.GetDetailsForSingleCustomerAddressAsync(
                createdAddress.Id, createdAddress.CustomerId ?? 0);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);

        var address = response.Result.CustomerAddress;
        Assert.NotNull(address);
        Assert.Equal(Fixture.BatchId, address?.Address1);
        Assert.Equal(createdAddress.FirstName, address?.FirstName);
        Assert.Equal(createdAddress.LastName, address?.LastName);
    }

    [SkippableFact, TestPriority(30)]
    public async Task Updates_Addresses()
    {
        Skip.If(!Fixture.CreatedAddresses.Any(), "A customer must be created with the CustomerTests first. Run in parallel.");
        var address = Fixture.CreatedAddresses.First();
        var request = new UpdateCustomerAddressRequest()
        {
            CustomerAddress = new()
            {
                FirstName = Fixture.BatchId
            }
        };
        var response =
            await _service.CustomerAddress.UpdateCustomerAddressAsync(address.Id, 
                address.CustomerId ?? 0, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);
        
        Assert.Equal(Fixture.BatchId, response.Result.CustomerAddress?.FirstName);
    }

    [SkippableFact, TestPriority(40)]
    public async Task Deletes_Addresses()
    {
        foreach (var address in Fixture.CreatedAddresses)
        {
            try
            {
                await _service.CustomerAddress.DeleteAddressFromCustomersAddressListAsync(
                        address.Id, address.CustomerId ?? 0);
            }
            catch (ApiException<ErrorResponse> ex)
            {
                _testOutputHelper.WriteLine($"{nameof(Deletes_Addresses)} failed. {ex.Message}");
            }
            catch (Exception ex)
            {
                _testOutputHelper.WriteLine($"{nameof(Deletes_Addresses)} failed. {ex.Message}");
            }
        }
    }

}
