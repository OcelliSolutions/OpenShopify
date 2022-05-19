using System;
using System.Collections.Generic;
using System.Diagnostics;
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
public class CustomerTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CustomersService _service; 
    private static string FirstName => "John";
    private static string LastName => "Doe";
    private static string Company => "OpenShopify";
    private static string Note => "Test note about this customer.";
    public CustomerTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new CustomersService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact, TestPriority(10)]
    public async Task CreateNewFulfillmentServiceAsync_CanCreate()
    {
        var request = new CustomerItem()
        {
            Customer = new Customer()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = $@"{Fixture.BatchId}@example.com",
                Addresses = new List<Address>
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
        var customer = await Fixture.Create(options: new CustomerCreateOptions()
        {
            Password = "loktarogar",
            PasswordConfirmation = "loktarogar",
            SendEmailInvite = false,
            SendWelcomeEmail = false,
        });

        Assert.NotNull(customer);
        Assert.Equal(Fixture.FirstName, customer.FirstName);
        Assert.Equal(Fixture.LastName, customer.LastName);
        Assert.Equal(Fixture.Note, customer.Note);
        Assert.NotNull(customer.Addresses);
    }


    [SkippableFact, TestPriority(20)]
    public async Task Counts_Customers()
    {
        var count = await Fixture.Service.CountAsync();

        Assert.True(count > 0);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Customers()
    {
        var list = await Fixture.Service.ListAsync();

        Assert.True(list.Items.Count() > 0);
    }


    [SkippableFact, TestPriority(20)]
    public async Task Gets_Customers()
    {
        var customer = await Fixture.Service.GetAsync(Fixture.Created.First().Id.Value);

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
        var customer = await Fixture.Service.GetAsync(Fixture.Created.First().Id.Value, "first_name,last_name");

        Assert.NotNull(customer);
        Assert.Equal(Fixture.FirstName, customer.FirstName);
        Assert.Equal(Fixture.LastName, customer.LastName);
        EmptyAssert.NullOrEmpty(customer.Note);
        EmptyAssert.NullOrEmpty(customer.Addresses);
        Assert.Null(customer.DefaultAddress);

    }
    [SkippableFact, TestPriority(20)]
    public async Task Searches_For_Customers()
    {
        // It takes anywhere between 3 seconds to 30 seconds for Shopify to index new customers for searches.
        // Rather than putting a 20 second Thread.Sleep in the test, we'll just assume it's successful if the
        // test doesn't throw an exception.
        bool threw = false;

        try
        {
            var search = await Fixture.Service.SearchAsync(new CustomerSearchListFilter { Query = "John" });
        }
        catch (ShopifyException ex)
        {
            Console.WriteLine($"{nameof(Searches_For_Customers)} failed. {ex.Message}");

            threw = true;
        }

        Assert.False(threw);
    }

    [SkippableFact, TestPriority(21)]
    public async Task SendInvite_Customers_Default()
    {
        var created = await Fixture.Create();
        long id = created.Id.Value;

        var invite = await Fixture.Service.SendInviteAsync(created.Id.Value);

        Assert.NotNull(invite);

    }

    [SkippableFact, TestPriority(21)]
    public async Task SendInvite_Customers_Custom()
    {
        var created = await Fixture.Create();
        long id = created.Id.Value;

        var options = new CustomerInvite()
        {
            Subject = "Custom Subject courtesy of ShopifySharp",
            CustomMessage = "Custom Message courtesy of ShopifySharp"
        };

        var invite = await Fixture.Service.SendInviteAsync(created.Id.Value, options);

        Assert.NotNull(invite);
        Assert.Equal(options.Subject, invite.Subject);
        Assert.Equal(options.CustomMessage, invite.CustomMessage);

    }

    [SkippableFact, TestPriority(21)]
    public async Task GetAccountActivationUrl_Customers()
    {
        var created = await Fixture.Create();
        long id = created.Id.Value;

        var url = await Fixture.Service.GetAccountActivationUrl(created.Id.Value);

        Assert.NotEmpty(url);
        Assert.Contains("account/activate", url);

    }
    [SkippableFact, TestPriority(30)]
    public async Task Updates_Customers()
    {
        string firstName = "Jane";
        var created = await Fixture.Create();
        long id = created.Id.Value;

        created.FirstName = firstName;
        created.Id = null;

        var updated = await Fixture.Service.UpdateAsync(id, created);

        // Reset the id so the Fixture can properly delete this object.
        created.Id = id;

        Assert.Equal(firstName, updated.FirstName);
    }

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


    [SkippableFact, TestPriority(40)]
    public async Task Deletes_Customers()
    {
        var created = await Fixture.Create();
        bool threw = false;

        try
        {
            await Fixture.Service.DeleteAsync(created.Id.Value);
        }
        catch (ShopifyException ex)
        {
            Console.WriteLine($"{nameof(Deletes_Customers)} failed. {ex.Message}");

            threw = true;
        }

        Assert.False(threw);
    }
}
