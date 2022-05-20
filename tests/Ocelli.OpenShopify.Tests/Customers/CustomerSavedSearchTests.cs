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
public class CustomerSavedSearchTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly CustomersService _service;

    public CustomerSavedSearchTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new CustomersService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact, TestPriority(1)]
    public async Task Creates_CustomerSavedSearch()
    {
        var request = new CreateCustomerSavedSearchRequest()
        {
            CustomerSavedSearch = new()
            {
                Name = $@"{Fixture.Company} {Fixture.BatchId}",
                Query = "-notes"
            }
        };
        var response = await _service.CustomerSavedSearch.CreateCustomerSavedSearchAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerSavedSearch, Fixture.MyShopifyUrl);

        var customerSavedSearch = response.Result.CustomerSavedSearch;
        Assert.NotNull(customerSavedSearch.Name);
        Assert.Equal(request.CustomerSavedSearch.Name, customerSavedSearch.Name);
        Assert.Equal(request.CustomerSavedSearch.Query, customerSavedSearch.Query);
        Fixture.CreatedCustomerSavedSearches.Add(customerSavedSearch);
    }

    [SkippableFact, TestPriority(2)]
    public async Task Counts_CustomerSavedSearch()
    {
        var response = await _service.CustomerSavedSearch.CountCustomerSavedSearchesAsync();
        Assert.True(response.Result.Count > 0);
    }

    [SkippableFact, TestPriority(2)]
    public async Task Lists_CustomerSavedSearch()
    {
        var response = await _service.CustomerSavedSearch.ListCustomerSavedSearchesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var customerSavedSearch in response.Result.CustomerSavedSearches)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(customerSavedSearch, Fixture.MyShopifyUrl);
        }

        Assert.True(response.Result.CustomerSavedSearches.Any());

        //Add any created items from previously failed tests to the created list for later deletion.
        Fixture.CreatedCustomerSavedSearches.AddRange(response.Result.CustomerSavedSearches.Where(fs =>
            !Fixture.CreatedCustomerSavedSearches.Exists(e => e.Id == fs.Id) &&
            fs.Name!.StartsWith(Fixture.Company)));
    }

    [SkippableFact, TestPriority(2)]
    public async Task Gets_CustomerSavedSearch()
    {
        Skip.If(!Fixture.CreatedCustomerSavedSearches.Any(), "This should be run with the create test.");
        var createdCustomerSavedSearch = Fixture.CreatedCustomerSavedSearches.First();
        var response = await _service.CustomerSavedSearch.GetCustomerSavedSearchAsync(createdCustomerSavedSearch.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomerSavedSearch, Fixture.MyShopifyUrl);

        var customerSavedSearch = response.Result.CustomerSavedSearch;

        Assert.NotNull(customerSavedSearch);
        Assert.Equal(createdCustomerSavedSearch.Name, customerSavedSearch.Name);
        Assert.Equal(createdCustomerSavedSearch.Query, customerSavedSearch.Query);
    }

    [SkippableFact, TestPriority(2)]
    public async Task Retrieves_Customers_In_A_Saved_Search()
    {
        Skip.If(!Fixture.CreatedCustomerSavedSearches.Any(), "This should be run with the create test.");
        var createdCustomerSavedSearch = Fixture.CreatedCustomerSavedSearches.First();
        var response =
            await _service.CustomerSavedSearch.ListCustomersReturnedByCustomerSavedSearchAsync(
                createdCustomerSavedSearch.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var customer in response.Result.Customers)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(customer, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Customers.Any(), "No customers returned. Cannot test.");
    }


    [SkippableFact, TestPriority(3)]
    public async Task Updates_CustomerSavedSearch()
    {
        Skip.If(!Fixture.CreatedCustomerSavedSearches.Any(), "This should be run with the create test.");
        var createdCustomerSavedSearch = Fixture.CreatedCustomerSavedSearches.First();
        var request = new UpdateCustomerSavedSearchRequest()
        {
            CustomerSavedSearch = new()
            {
                Id = createdCustomerSavedSearch.Id,
                Name = $@"{createdCustomerSavedSearch.Name} (UPDATED)"
            }
        };
        var response =
            await _service.CustomerSavedSearch.UpdateCustomerSavedSearchAsync(createdCustomerSavedSearch.Id, request);
        
        Assert.Equal(request.CustomerSavedSearch.Name, response.Result.CustomerSavedSearch.Name);
        //since the query was not sent in the update, the response should show the original.
        Assert.Equal(createdCustomerSavedSearch.Query, response.Result.CustomerSavedSearch.Query);

        // Reset the id so the Fixture can properly delete this object.
        Fixture.CreatedCustomerSavedSearches.Remove(createdCustomerSavedSearch);
        Fixture.CreatedCustomerSavedSearches.Add(response.Result.CustomerSavedSearch);
    }

    [SkippableFact, TestPriority(4)]
    public async Task Deletes_CustomerSavedSearch()
    {
        Skip.If(Fixture.CreatedCustomerSavedSearches.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var customerSavedSearch in Fixture.CreatedCustomerSavedSearches)
        {
            try
            {
                await _service.CustomerSavedSearch.DeleteCustomerSavedSearchAsync(customerSavedSearch.Id);
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
