using System;
using System.Reflection;
using System.Text.Json;

namespace Ocelli.OpenShopify.Tests.Helpers;

public class AdditionalPropertiesHelper
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AdditionalPropertiesHelper(ITestOutputHelper testOutputHelper) => _testOutputHelper = testOutputHelper;
    
    public void CheckAdditionalProperties(object? obj, string path)
    {
        if (obj == null) return;
        var objType = obj.GetType();
        var properties = objType.GetProperties();
        foreach (var property in properties)
        {
            var currentPath = $@"{path}.{property.Name}";
            var propValue = property.GetValue(obj, null);
            if (property.PropertyType.Assembly == objType.Assembly &&
                property.Name != nameof(AccessScope.AdditionalProperties))
                //_testOutputHelper.WriteLine(currentPath);
                this.CheckAdditionalProperties(propValue, currentPath);
            else if (property.Name == nameof(AccessScope.AdditionalProperties))
            {
                if (propValue != null && ((IDictionary<string, object>)propValue).Count == 0) continue;

                var nonNullProperties =
                    ((IDictionary<string, object?>)propValue! ?? throw new InvalidOperationException())
                    .Where(kvp => kvp.Value != null)
                    .ToList();

                if (nonNullProperties.Count == 0) continue;
                _testOutputHelper.WriteLine("{0}: {1}", currentPath, JsonSerializer.Serialize(nonNullProperties));

                Assert.Empty(nonNullProperties);
            }
        }
    }
    
    /*
    public void CheckAdditionalProperties(Type type, string path)
    {
        // get all properties of this type
        Console.WriteLine($"Describing type {type.Name}");
        var propertyInfos = type.GetProperties();
        foreach (var propertyInfo in propertyInfos)
        {
            var currentPath = $@"{path}.{propertyInfo.Name}";
            var propValue = propertyInfo.GetValue(type, null);
            Console.WriteLine($"Has property {propertyInfo.Name} of type {propertyInfo.PropertyType.Name}");
            // is a custom class type? describe it too
            if (propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.StartsWith("System."))
            {
                // point B, we call the function type this property
                CheckAdditionalProperties(propertyInfo.PropertyType, path);
            }
            else if (propertyInfo.Name == nameof(AccessScope.AdditionalProperties))
            {
                if (propValue != null && ((IDictionary<string, object>)propValue).Count == 0) continue;

                var nonNullProperties =
                    ((IDictionary<string, object?>)propValue! ?? throw new InvalidOperationException())
                    .Where(kvp => kvp.Value != null)
                    .ToList();

                if (nonNullProperties.Count == 0) continue;
                _testOutputHelper.WriteLine("{0}: {1}", currentPath, JsonSerializer.Serialize(nonNullProperties));

                Assert.Empty(nonNullProperties);
            }
        }
        // done with all properties
        // we return to the point where we were called
        // point A for the first call
        // point B for all properties of type custom class
    }
    */
}
