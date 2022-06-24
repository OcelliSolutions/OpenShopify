using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Ocelli.OpenShopify.Tests;
public class MiscellaneousTests
{
    [Fact]
    void AdditionalProperties_CanUpdate()
    {
        var types = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.Namespace.StartsWith("Ocelli.OpenShopify"));

        foreach (var t in types)
        {
            Console.WriteLine(t.Name);
        }
    }
}
