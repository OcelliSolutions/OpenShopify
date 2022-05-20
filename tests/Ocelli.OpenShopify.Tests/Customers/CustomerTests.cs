using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Customers;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CustomerTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CustomersService _service; 

    public CustomerTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new CustomersService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;

    [SkippableFact, TestPriority(10)]
    public async Task CreateCustomerAsync_CanCreate()
    {
        var request = Fixture.CreateCustomerRequest;
        var response = await _service.Customer.CreateCustomerAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Customer, Fixture.MyShopifyUrl);

        var created = response.Result.Customer;
        Assert.NotNull(created);
        Assert.Equal(Fixture.FirstName, created.FirstName);
        Assert.Equal(Fixture.LastName, created.LastName);
        Assert.Equal(Fixture.Company, created.Addresses?.First().Company);
        Assert.Equal(Fixture.Note, created.Note);
        Assert.NotNull(created.Addresses);
        Fixture.CreatedCustomers.Add(created);
    }
    
    [SkippableFact, TestPriority(10)]
    public async Task Creates_Customers_With_Options()
    {
        var request = Fixture.CreateCustomerRequest;
        request.Customer.Email = $@"{Fixture.BatchId}+options@example.com";
        request.Customer.Password = "sample";
        request.Customer.PasswordConfirmation = "sample";
        request.Customer.SendEmailInvite = false;
        request.Customer.SendEmailWelcome = false;
        var created = await _service.Customer.CreateCustomerAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(created.Result.Customer, Fixture.MyShopifyUrl);
        var customer = created.Result.Customer;
        Assert.NotNull(customer);
        Assert.Equal(Fixture.FirstName, customer.FirstName);
        Assert.Equal(Fixture.LastName, customer.LastName);
        Assert.Equal(Fixture.Note, customer.Note);
        Assert.NotNull(customer.Addresses);
        Fixture.CreatedCustomers.Add(customer ?? throw new InvalidOperationException());
    }
    
    [SkippableFact, TestPriority(20)]
    public async Task Counts_Customers()
    {
        var response = await _service.Customer.CountCustomersAsync(CancellationToken.None);
        Assert.True(response.Result.Count > 0);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Customers()
    {
        var response = await _service.Customer.ListCustomersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var customerSavedSearch in response.Result.Customers)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(customerSavedSearch, Fixture.MyShopifyUrl);
        }

        Assert.True(response.Result.Customers.Any());

        //Add any created items from previously failed tests to the created list for later deletion.
        Fixture.CreatedCustomers.AddRange(response.Result.Customers.Where(fs =>
            !Fixture.CreatedCustomers.Exists(e => e.Id == fs.Id) &&
            fs.FirstName!.StartsWith(Fixture.FirstName)));
    }
    
    [SkippableFact, TestPriority(20)]
    public async Task Gets_Customer()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "This should be run with the create test.");
        var createdCustomer = Fixture.CreatedCustomers.First();
        var response = await _service.Customer.GetCustomerAsync(createdCustomer.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Customer, Fixture.MyShopifyUrl);

        var customer = response.Result.Customer;
        Assert.NotNull(customer);
        Assert.Equal(Fixture.FirstName, customer.FirstName);
        Assert.Equal(Fixture.LastName, customer.LastName);
        Assert.Equal(Fixture.Note, customer.Note);
        Assert.NotNull(customer.Addresses);
        Assert.NotNull(customer.DefaultAddress);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Gets_Customers_With_Options()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "This should be run with the create test.");
        var response =
            await _service.Customer.GetCustomerAsync(Fixture.CreatedCustomers.First().Id,
                "first_name,last_name");
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Customer, Fixture.MyShopifyUrl);

        var customer = response.Result.Customer;
        Assert.NotNull(customer);
        Assert.Equal(Fixture.FirstName, customer.FirstName);
        Assert.Equal(Fixture.LastName, customer.LastName);
        Assert.Null(customer.Note);
        Assert.Null(customer.Addresses);
        Assert.Null(customer.DefaultAddress);

    }
    [SkippableFact, TestPriority(20)]
    public async Task Searches_For_Customers()
    {
        // It takes anywhere between 3 seconds to 30 seconds for Shopify to index new customers for searches.
        // Rather than putting a 20 second Thread.Sleep in the test, we'll just assume it's successful if the
        // test doesn't throw an exception.
        var threw = false;

        try
        {
            var response = await _service.Customer.SearchForCustomersThatMatchSuppliedQueryAsync(query: Fixture.FirstName);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            Fixture.CreatedCustomers.AddRange(response.Result.Customers);
            foreach (var customer in response.Result.Customers)
                _additionalPropertiesHelper.CheckAdditionalProperties(customer, Fixture.MyShopifyUrl);
        }
        catch (Exception ex)
        {
            _testOutputHelper.WriteLine(ex.Message);
            threw = true;
        }

        Assert.False(threw);
    }

    [SkippableFact, TestPriority(21)]
    public async Task SendInvite_Customers_Default()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "This should be run with the create test.");
        var response = await _service.Customer.SendAccountInviteToCustomerAsync(Fixture.CreatedCustomers.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        Assert.NotNull(response.Result);
    }

    [SkippableFact, TestPriority(21)]
    public async Task SendInvite_Customers_Custom()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "This should be run with the create test.");
        var request = new CreateCustomerInviteRequest()
        {
            CustomerInvite = new CreateCustomerInvite()
            {
                Subject = "Custom subject courtesy of OpenShopify",
                CustomMessage = "Custom message courtesy of OpenShopify"
            }
        };
        var response = await _service.Customer.SendAccountInviteToCustomerAsync(Fixture.CreatedCustomers.First().Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        var invite = response.Result.CustomerInvite;
        Assert.NotNull(invite);
        Assert.Equal(request.CustomerInvite.Subject, invite.Subject);
        Assert.Equal(request.CustomerInvite.CustomMessage, invite.CustomMessage);

    }

    [SkippableFact, TestPriority(21)]
    public async Task GetAccountActivationUrl_Customers()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "This should be run with the create test.");
        var response = await _service.Customer.CreateAccountActivationUrlForCustomerAsync(Fixture.CreatedCustomers.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var url = response.Result;
        
        Assert.NotNull(url.AccountActivationUrl);
        _testOutputHelper.WriteLine(JsonSerializer.Serialize(url));
        Assert.Contains("account/activate", url.AccountActivationUrl!);
    }

    [SkippableFact, TestPriority(30)]
    public async Task Updates_Customers()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "This should be run with the create test.");
        const string lastName = "Sample";
        var createdCustomer = Fixture.CreatedCustomers.First();
        var request = new UpdateCustomerRequest()
        {
            Customer = new UpdateCustomer()
            {
                Id = createdCustomer.Id,
                LastName = lastName
            }
        };

        var response = await _service.Customer.UpdateCustomerAsync(createdCustomer.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Customer, Fixture.MyShopifyUrl);

        var updated = response.Result.Customer;
        Assert.Equal(lastName, updated.LastName);
        Assert.Equal(createdCustomer.Email, updated.Email);
        Assert.Equal(createdCustomer.Note, updated.Note);

        // Reset the id so the Fixture can properly delete this object.
        Fixture.CreatedCustomers.Remove(createdCustomer);
        Fixture.CreatedCustomers.Add(response.Result.Customer);
    }
    
    [SkippableFact, TestPriority(31)]
    public async Task Updates_Customers_With_Options()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "A customer must be created with the CustomerTests first. Run in parallel.");
        var createdCustomer = Fixture.CreatedCustomers.First();
        const string lastName = "Sample";
        var request = new UpdateCustomerRequest()
        {
            Customer = new()
            {
                Id = createdCustomer.Id,
                LastName = lastName,
                Password = "9AVShqi85xC1",
                PasswordConfirmation = "9AVShqi85xC1"
            }
        };
        var response = await _service.Customer.UpdateCustomerAsync(createdCustomer.Id, request);

        Assert.Equal(lastName, response.Result.Customer.LastName);

        // Reset the id so the Fixture can properly delete this object.
        Fixture.CreatedCustomers.Remove(createdCustomer);
        Fixture.CreatedCustomers.Add(response.Result.Customer);
    }

    [SkippableFact, TestPriority(40)]
    public async Task Deletes_Customers()
    {
        Skip.If(Fixture.CreatedCustomers.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var customer in Fixture.CreatedCustomers)
        {
            try
            {
                await _service.Customer.DeleteCustomerAsync(customer.Id);
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
