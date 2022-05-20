﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        var customer = await Fixture.CreateTestCustomer();

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
        Fixture.CreatedAddresses.Add(created);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Addresses()
    {
        Skip.If(!Fixture.CreatedAddresses.Any(), "A customer must be created with the CustomerTests first. Run in parallel.");
        var address = Fixture.CreatedAddresses.First();
        var response = await _service.CustomerAddress.ListAddressesForCustomerAsync(address.CustomerId);
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
                createdAddress.Id, createdAddress.CustomerId);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);

        var address = response.Result.CustomerAddress;
        Assert.NotNull(address);
        Assert.Equal(Fixture.BatchId, address.Address1);
        Assert.Equal(createdAddress.FirstName, address.FirstName);
        Assert.Equal(createdAddress.LastName, address.LastName);
    }

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
                createdAddress.CustomerId, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerAddress, Fixture.MyShopifyUrl);
        
        Assert.Equal(Fixture.BatchId, response.Result.CustomerAddress.LastName);

        // Reset the id so the Fixture can properly delete this object.
        Fixture.CreatedAddresses.Remove(createdAddress);
        Fixture.CreatedAddresses.Add(response.Result.CustomerAddress);
    }

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
                        address.Id, address.CustomerId);
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

}
