using System;
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
        Scopes = new List<AuthorizationScope?>();

        Task.Run(async () => await this.LoadScopes()).Wait();
    }
    
    internal string BatchId { get; }
    public int DaysToTest { get; set; }
    public string AccessToken { get; set; }
    public string MyShopifyUrl { get; set; }

    public List<AuthorizationScope?> Scopes { get; set; }
    public List<ApplicationCredit> CreatedApplicationCredits = new();
    public List<Customer> CreatedCustomers = new();
    public List<CustomerAddress> CreatedCustomerAddresses = new();
    public List<Address> CreatedAddresses = new();
    public List<FulfillmentService> CreatedFulfillmentServices = new();
    
    public void ValidateScopes(List<AuthorizationScope> requiredPermissions)
    {
        foreach (var requiredPermission in requiredPermissions)
        {
            Skip.If(!Scopes.Contains(requiredPermission), $@"`{MyShopifyUrl}` credentials do not have the `{requiredPermission}` scope(s). Endpoint cannot be tested.");
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
                Scopes = scopes.Result.AccessScopes.Select(s => s.Handle).ToList();
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