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
    private static string FirstName => "OpenShopify";
    private static string LastName => "Doe";
    private static string Company => "OpenShopify";
    private static string Note => "Test note about this customer.";

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
        var request = new CreateCustomerRequest()
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
                        Address1 = "123 4th Street",
                        City = "Minneapolis",
                        Province = "Minnesota",
                        ProvinceCode = "MN",
                        Zip = "55401",
                        Phone = "555-555-5555",
                        FirstName = "John",
                        LastName = "Doe",
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
        var created =
            await _service.Customer.CreateCustomerAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(created.Result.Customer, Fixture.MyShopifyUrl);

        var customer = created.Result.Customer;

        Assert.NotNull(customer);
        Assert.Equal(FirstName, customer?.FirstName);
        Assert.Equal(LastName, customer?.LastName);
        Assert.Equal(Company, customer?.Addresses?.First().Company);
        Assert.Equal(Note, customer?.Note);
        Assert.NotNull(customer?.Addresses);
        if (customer != null)
        {
            Fixture.CreatedCustomers.Add(customer);
        }
    }
    
    [SkippableFact, TestPriority(10)]
    public async Task Creates_Customers_With_Options()
    {
        var request = new CreateCustomerRequest()
        {
            Customer = new CreateCustomer()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = $@"{Fixture.BatchId}+options@example.com",
                AcceptsMarketing = false,
                Addresses = new List<CreateAddress>
                {
                    new()
                    {
                        Address1 = "123 4th Street",
                        City = "Minneapolis",
                        Province = "Minnesota",
                        ProvinceCode = "MN",
                        Zip = "55401",
                        Phone = "555-555-5555",
                        FirstName = "John",
                        LastName = "Doe",
                        Company = Company,
                        Country = "United States",
                        CountryCode = "US",
                        Default = true,
                    }
                },
                VerifiedEmail = true,
                Note = Note,
                State = "enabled", 
                Password = "sample", 
                PasswordConfirmation = "sample", 
                SendEmailInvite = false, 
                SendEmailWelcome = false
            }
        };
        var created = await _service.Customer.CreateCustomerAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(created.Result.Customer, Fixture.MyShopifyUrl);
        var customer = created.Result.Customer;
        Assert.NotNull(customer);
        Assert.Equal(FirstName, customer?.FirstName);
        Assert.Equal(LastName, customer?.LastName);
        Assert.Equal(Note, customer?.Note);
        Assert.NotNull(customer?.Addresses);
        Fixture.CreatedCustomers.Add(customer ?? throw new InvalidOperationException());
    }
    
    [SkippableFact, TestPriority(20)]
    public async Task Counts_Customers()
    {

        var response = await _service.Customer.RetrieveCountOfCustomersAsync(CancellationToken.None);

        Assert.True(response.Result.Count > 0);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Customers()
    {
        var response = await _service.Customer.RetrieveListOfCustomersAsync();

        Assert.True(response.Result.Customers?.Any());
    }


    [SkippableFact, TestPriority(20)]
    public async Task Gets_Customer()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "This should be run with the create test.");
        var response = await _service.Customer.RetrieveSingleCustomerAsync(Fixture.CreatedCustomers.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Customer, Fixture.MyShopifyUrl);

        var customer = response.Result.Customer;
        Assert.NotNull(customer);
        Assert.Equal(FirstName, customer?.FirstName);
        Assert.Equal(LastName, customer?.LastName);
        Assert.Equal(Note, customer?.Note);
        Assert.NotNull(customer?.Addresses);
        Assert.NotNull(customer?.DefaultAddress);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Gets_Customers_With_Options()
    {
        Skip.If(!Fixture.CreatedCustomers.Any(), "This should be run with the create test.");
        var response =
            await _service.Customer.RetrieveSingleCustomerAsync(Fixture.CreatedCustomers.First().Id,
                "first_name,last_name");
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Customer, Fixture.MyShopifyUrl);

        var customer = response.Result.Customer;
        Assert.NotNull(customer);
        Assert.Equal(FirstName, customer?.FirstName);
        Assert.Equal(LastName, customer?.LastName);
        Assert.Null(customer?.Note);
        Assert.Null(customer?.Addresses);
        Assert.Null(customer?.DefaultAddress);

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
            var response = await _service.Customer.SearchForCustomersThatMatchSuppliedQueryAsync(query: FirstName);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            if (response.Result.Customers != null)
            {
                Fixture.CreatedCustomers.AddRange(response.Result.Customers);
                foreach (var customer in response.Result.Customers)
                    _additionalPropertiesHelper.CheckAdditionalProperties(customer, Fixture.MyShopifyUrl);
            }
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
        Assert.Equal(request.CustomerInvite.Subject, invite?.Subject);
        Assert.Equal(request.CustomerInvite.CustomMessage, invite?.CustomMessage);

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
        var created = Fixture.CreatedCustomers.First();
        var request = new UpdateCustomerRequest()
        {
            Customer = new UpdateCustomer()
            {
                Id = created.Id,
                LastName = lastName
            }
        };

        var response = await _service.Customer.UpdateCustomerAsync((long)created.Id!, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Customer, Fixture.MyShopifyUrl);

        var updated = response.Result.Customer;
        Assert.Equal(lastName, updated?.LastName);
    }
    /*
    [SkippableFact, TestPriority(30)]
    public async Task Updates_Customers_With_Options()
    {
        string firstName = "Jane";
        var created = await Fixture.Create();
        long id = created.Id.Value;

        created.FirstName = firstName;
        created.Id = null;

        var updated = await Fixture.Service.UpdateAsync(id, created, new CustomerUpdateOptions()
        {
            Password = "loktarogar",
            PasswordConfirmation = "loktarogar"
        });

        // Reset the id so the Fixture can properly delete this object.
        created.Id = id;

        Assert.Equal(firstName, updated.FirstName);
    }

    [SkippableFact, TestPriority(31)]
    public async Task Can_Be_Partially_Updated()
    {
        string newFirstName = "Sheev";
        string newLastName = "Palpatine";
        var created = await Fixture.Create();
        var updated = await Fixture.Service.UpdateAsync(created.Id.Value, new Customer()
        {
            FirstName = newFirstName,
            LastName = newLastName
        });

        Assert.Equal(created.Id, updated.Id);
        Assert.Equal(newFirstName, updated.FirstName);
        Assert.Equal(newLastName, updated.LastName);

        // In previous versions of ShopifySharp, the updated JSON would have sent 'email=null' or 'note=null', clearing out the email address.
        Assert.Equal(created.Email, updated.Email);
        Assert.Equal(created.Note, updated.Note);
    }

    */
    [SkippableFact, TestPriority(40)]
    public async Task Deletes_Customers()
    {
        foreach (var customer in Fixture.CreatedCustomers)
        {

            try
            {
                var response = await _service.Customer.DeleteCustomerAsync(customer.Id);
            }
            catch (ApiException<ErrorResponse> ex)
            {
                _testOutputHelper.WriteLine($"{nameof(Deletes_Customers)} failed. {ex.Message}");
            }
            catch (Exception ex)
            {
                _testOutputHelper.WriteLine($"{nameof(Deletes_Customers)} failed. {ex.Message}");
            }
        }
    }
}
