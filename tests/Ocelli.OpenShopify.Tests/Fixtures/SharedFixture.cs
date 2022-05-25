﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Models;
using shortid;
using shortid.Configuration;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Ocelli.OpenShopify.Tests.Fixtures;

public class SharedFixture : IDisposable
{
    public SharedFixture()
    {
        var apiKeyJson = File.ReadAllText("api_key.json");
        Debug.Assert(!string.IsNullOrWhiteSpace(apiKeyJson), "Please create an `api_key.json` file");

        var config = JsonSerializer.Deserialize<ShopifyConfig>(apiKeyJson) ??
                     throw new InvalidOperationException("Could not deserialize the api_key.json file");
        BatchId = ShortId.Generate(new GenerationOptions(true, false, 8));

        DaysToTest = 1;
#if DEBUG
        DaysToTest = 10;
#endif
        AccessToken = config.AccessToken;
        MyShopifyUrl = config.MyShopifyUrl;
        //Scopes = new List<AuthorizationScope?>();

        Task.Run(async () => await this.LoadScopes()).Wait();
    }

    internal string BatchId { get; }
    public int DaysToTest { get; set; }
    public string AccessToken { get; set; }
    public string MyShopifyUrl { get; set; }

    public string FirstName => "John (OpenShopify)";
    public string LastName => "Doe";
    public string Company => "OpenShopify";
    public string Note => "Test note about this customer.";
    public string Email => "foo@example.com";

    public List<AuthorizationScope> Scopes = new();
    public List<Address> CreatedAddresses = new();
    public List<ApplicationCredit> CreatedApplicationCredits = new();
    public List<Blog> CreatedBlogs = new();
    public List<Collect> CreatedCollects = new();
    public List<Customer> CreatedCustomers = new();
    public List<CustomerSavedSearch> CreatedCustomerSavedSearches  = new();
    //public List<CustomerAddress> CreatedCustomerAddresses = new();
    public List<FulfillmentService> CreatedFulfillmentServices = new();
    public List<GiftCard> CreatedGiftCards = new();
    public List<Order> CreatedOrders = new();
    public List<PriceRule> CreatedPriceRule = new();
    public List<Product> CreatedProducts = new();
    public List<Webhook> CreatedWebhooks = new();

    public void ValidateScopes(List<AuthorizationScope> requiredPermissions)
    {
        foreach (var requiredPermission in requiredPermissions)
        {
            Skip.If(!Scopes.Contains(requiredPermission),
                $@"`{MyShopifyUrl}` credentials do not have the `{requiredPermission}` scope(s). Endpoint cannot be tested.");
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task LoadScopes()
    {
        try
        {
            var service = new AccessService(MyShopifyUrl, AccessToken);
            var scopes = await service.AccessScope.ListAccessScopesAsync();
            if (scopes.Result.AccessScopes != null)
            {
                Scopes = scopes.Result.AccessScopes.Select(s => (AuthorizationScope)s.Handle).ToList();
            }
        }
        catch (ApiException<ErrorResponse?> ex)
        {
            Console.WriteLine($@"SubDomain: {MyShopifyUrl} - {ex.Message}");
        }
    }

    [CollectionDefinition("Shared collection")]
    public class SharedCollection : ICollectionFixture<SharedFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    public CreateCustomerRequest CreateCustomerRequest =>
        new()
        {
            Customer = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = $@"{BatchId}@example.com",
                //AcceptsMarketing = false,
                Addresses = new List<CreateCustomerAddress>()
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

    public CreatePriceRuleRequest CreatePriceRuleRequest =>
        new ()
        {
            PriceRule = new()
            {
                Title = $@"{Company} PriceRule ({BatchId})",
                ValueType = "percentage",
                TargetType = "line_item",
                TargetSelection = "all",
                AllocationMethod = "across",
                Value = (decimal)-10.0,
                CustomerSelection = "all",
                OncePerCustomer = false, PrerequisiteCollectionIds = new List<long>(),
                PrerequisiteSubtotalRange = new PrerequisiteValueRange()
                {
                    GreaterThanOrEqualTo = 40
                },
                StartsAt = new DateTimeOffset(DateTime.Now)
            }
        };

    public CreateOrderRequest CreateSimpleOrder(long variantId) =>
        new()
        {
            Order = new()
            {
                Email = Email,
                LineItems = new List<LineItem>()
                {
                    new ()
                    {
                        VariantId = variantId,
                        Quantity = 1
                    }
                }
            }
        };

    public CreateFulfillmentServiceRequest CreateFulfillmentServiceRequest =>
    new()
    {
        FulfillmentService = new CreateFulfillmentService()
        {
            Name = $@"{Company} FulfillmentService ({BatchId})",
            Email = Email,
            Format = FulfillmentServiceFormat.json,
            CallbackUrl = "http://sample.com/callback"
        }
    };

    public CreateProductRequest CreateProductRequest =>
        new()
        {
            Product = new()
            {
                Title = $@"Burton Custom Freestyle 151 ({BatchId})",
                BodyHtml = @"\u003cstrong\u003eGood snowboard!\u003c\/strong\u003e",
                Vendor = Company,
                ProductType = "Snowboard",
                Tags = @"Barnes \u0026 Noble, Big Air, John's Fav"
            }
        };
}

[AttributeUsage(AttributeTargets.Method)]
    public class TestPriorityAttribute : Attribute
    {
        public int Priority { get; private init; }

        public TestPriorityAttribute(int priority) => Priority = priority;
    }

public class PriorityOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(
        IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        var assemblyName = typeof(TestPriorityAttribute).AssemblyQualifiedName!;
        var sortedMethods = new SortedDictionary<int, List<TTestCase>>();
        foreach (var testCase in testCases)
        {
            var priority = testCase.TestMethod.Method
                .GetCustomAttributes(assemblyName)
                .FirstOrDefault()
                ?.GetNamedArgument<int>(nameof(TestPriorityAttribute.Priority)) ?? 0;

            GetOrCreate(sortedMethods, priority).Add(testCase);
        }

        foreach (var testCase in
                 sortedMethods.Keys.SelectMany(
                     priority => sortedMethods[priority].OrderBy(
                         testCase => testCase.TestMethod.Method.Name)))
        {
            yield return testCase;
        }
    }

    private static TValue GetOrCreate<TKey, TValue>(
        IDictionary<TKey, TValue> dictionary, TKey key)
        where TKey : struct
        where TValue : new() =>
        dictionary.TryGetValue(key, out var result)
            ? result
            : dictionary[key] = new TValue();
}