using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests;
public class MiscellaneousTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public MiscellaneousTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void AdditionalProperties_CanUpdate()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.FullName != null && a.FullName.StartsWith("Ocelli.OpenShopify") && !a.FullName.Contains("Test"));
        foreach (var assembly in assemblies)
        {
            foreach (var type in assembly.GetTypes())
            {
                var properties = type.GetProperties().Where(p => p.Name == nameof(AccessScope.AdditionalProperties));
                foreach (var property in properties)
                {
                    _testOutputHelper.WriteLine($@"{type.Name}.{property.Name}");
                    var c = Activator.CreateInstance(type);
                    c?.GetType().GetProperty(property.Name)?.SetValue(c, null, null);
                }

            }
        }
    }
}
