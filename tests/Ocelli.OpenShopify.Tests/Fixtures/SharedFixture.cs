using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
        try
        {
            var apiKeyJson = File.ReadAllText("api_keys.json");
            Debug.Assert(!string.IsNullOrWhiteSpace(apiKeyJson), "Please create a `api_key.json` file");

            var settings = JsonSerializer.Deserialize<ApiKeyList>(apiKeyJson);

            ApiKeys = settings?.ShopifyConfigs?.Select(c => new ApiKey(c.AccessToken, c.MyShopifyUrl)).ToList() ?? throw new InvalidOperationException("Could not deserialize the api_keys.");
            Debug.Assert(ApiKeys != null, "Please specify some api keys in `api_keys.json` before testing");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception ex)
        {
            throw new KeyNotFoundException($@"Please create a `api_keys.json` file. {ex.Message}");
        }
        BatchId = ShortId.Generate(new GenerationOptions(true, false, 8));
        Task.Run(async () => await this.LoadScopes()).Wait();
    }

    internal List<ApiKey> ApiKeys { get; set; } = new();
    internal string BatchId { get; }

    public void Dispose()
    {
        ApiKeys.Clear(); 
        GC.SuppressFinalize(this);
    }


    public async Task LoadScopes()
    {
        foreach (var key in ApiKeys)
            try
            {
                var service = new AccessService(key.MyShopifyUrl, key.AccessToken);
                var scopes = await service.AccessScope.GetListOfAccessScopesAsync();
                if (scopes.AccessScopes != null)
                {
                    key.Scopes = scopes.AccessScopes.Select(s => s.Handle).ToList();
                }
            }
            catch (ApiException<ErrorResponse?> ex)
            {
                Console.WriteLine($@"SubDomain: {key.MyShopifyUrl} - {ex.Message}");
            }
    }
}

[CollectionDefinition("Shared collection")]
public class SharedCollection : ICollectionFixture<SharedFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class TestPriorityAttribute : Attribute
{
    public int Priority { get; private set; }

    public TestPriorityAttribute(int priority) => Priority = priority;
}
public class PriorityOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(
        IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        string assemblyName = typeof(TestPriorityAttribute).AssemblyQualifiedName!;
        var sortedMethods = new SortedDictionary<int, List<TTestCase>>();
        foreach (TTestCase testCase in testCases)
        {
            int priority = testCase.TestMethod.Method
                .GetCustomAttributes(assemblyName)
                .FirstOrDefault()
                ?.GetNamedArgument<int>(nameof(TestPriorityAttribute.Priority)) ?? 0;

            GetOrCreate(sortedMethods, priority).Add(testCase);
        }

        foreach (TTestCase testCase in
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
        dictionary.TryGetValue(key, out TValue? result)
            ? result
            : (dictionary[key] = new TValue());
}
