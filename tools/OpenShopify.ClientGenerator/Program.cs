using System.Text.RegularExpressions;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.OperationNameGenerators;
using OpenShopify.ClientGenerator;

var shopifyFiles = Directory.EnumerateFiles("../../../../../", "open-shopify-*.yaml", SearchOption.AllDirectories);
foreach (var shopifyFile in shopifyFiles)
{
    var className = shopifyFile[shopifyFile.IndexOf("open-shopify-")..];
    className = className.Replace("open-shopify-", string.Empty).Replace(".yaml", string.Empty);
    className = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(className).Replace("-", string.Empty);
    var document = OpenApiYamlDocument.FromFileAsync(shopifyFile).Result;
    var settings = new CSharpClientGeneratorSettings()
    {
        ClassName = "{controller}Client",
        ClientBaseClass = "ShopifyClientBase",
        OperationNameGenerator = new MultipleClientsFromFirstTagAndOperationIdGenerator(),
        GenerateClientInterfaces = true,
        GenerateOptionalParameters = true,
        GenerateUpdateJsonSerializerSettingsMethod = false,
        ClientClassAccessModifier = "internal",
        AdditionalNamespaceUsages = new[] { "System.Text.Json" },
        GenerateExceptionClasses = false,
        ParameterNameGenerator = new CustomParameterNameGenerator(),
        CSharpGeneratorSettings =
        {
            Namespace = $@"Ocelli.OpenShopify", 
            EnumNameGenerator = new CustomEnumNameGenerator(),
            JsonLibrary = CSharpJsonLibrary.SystemTextJson,
            GenerateOptionalPropertiesAsNullable = true,
            GenerateNullableReferenceTypes = true,
            GenerateDefaultValues = true,
            GenerateDataAnnotations = true, 
            ExcludedTypeNames = new []{ "ErrorResponse" },
            PropertyNameGenerator = new CustomPropertyNameGenerator()
        }
    };

    var generator = new CSharpClientGenerator(document, settings);
    var code = generator.GenerateFile();
    await File.WriteAllTextAsync($@"../../../../../src/Ocelli.OpenShopify/Clients/Shopify{className}Client.cs", code);

}

public class CustomParameterNameGenerator : IParameterNameGenerator
{
    public string Generate(OpenApiParameter parameter, IEnumerable<OpenApiParameter> allParameters)
    {
        var name = !string.IsNullOrEmpty(parameter.OriginalName) ?
            parameter.OriginalName : parameter.Name;

        if (string.IsNullOrEmpty(name))
        {
            return "unnamed";
        }
        
        name = name.Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries).Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (s1, s2) => s1 + s2);


        var variableName = ConversionUtilities.ConvertToLowerCamelCase(name
            .Replace("-", "_")
            .Replace(".", "_")
            .Replace("$", string.Empty)
            .Replace("@", string.Empty)
            .Replace("[", string.Empty)
            .Replace("]", string.Empty), true);

        if (allParameters.Count(p => p.Name == name) > 1)
        {
            return variableName + parameter.Kind;
        }

        return variableName;
    }
}


namespace OpenShopify.ClientGenerator
{
    public class CustomPropertyNameGenerator : IPropertyNameGenerator
    {
        /// <summary>Generates the property name.</summary>
        /// <param name="property">The property.</param>
        /// <returns>The new name.</returns>
        public virtual string Generate(JsonSchemaProperty property) =>
            ConversionUtilities.ConvertToUpperCamelCase(property.Name
                    .Replace("\"", string.Empty)
                    .Replace("@", string.Empty)
                    .Replace("?", string.Empty)
                    .Replace("$", "Dollar")
                    .Replace("%", "perc")
                    .Replace("[", string.Empty)
                    .Replace("]", string.Empty)
                    .Replace("(", "_")
                    .Replace(")", string.Empty)
                    .Replace(".", "-")
                    .Replace("=", "-")
                    .Replace("_", "-")
                    .Replace("+", "plus"), true)
                .Replace("*", "Star")
                .Replace(":", "_")
                .Replace("-", "_")
                .Replace("#", "_");
    }
}

public class CustomEnumNameGenerator : IEnumNameGenerator
{
    private readonly static Regex _invalidNameCharactersPattern = new Regex(@"[^\p{Lu}\p{Ll}\p{Lt}\p{Lm}\p{Lo}\p{Nl}\p{Mn}\p{Mc}\p{Nd}\p{Pc}\p{Cf}]");
    private const string _defaultReplacementCharacter = "_";

    /// <summary>Generates the enumeration name/key of the given enumeration entry.</summary>
    /// <param name="index">The index of the enumeration value (check <see cref="JsonSchema.Enumeration" /> and <see cref="JsonSchema.EnumerationNames" />).</param>
    /// <param name="name">The name/key.</param>
    /// <param name="value">The value.</param>
    /// <param name="schema">The schema.</param>
    /// <returns>The enumeration name.</returns>
    public string Generate(int index, string name, object value, JsonSchema schema)
    {
        if (string.IsNullOrEmpty(name))
        {
            return "Empty";
        }

        switch (name)
        {
            case ("="):
                name = "Eq";
                break;
            case ("!="):
                name = "Ne";
                break;
            case (">"):
                name = "Gt";
                break;
            case ("<"):
                name = "Lt";
                break;
            case (">="):
                name = "Ge";
                break;
            case ("<="):
                name = "Le";
                break;
            case ("~="):
                name = "Approx";
                break;
        }

        if (name.StartsWith("-"))
        {
            name = "Minus" + name.Substring(1);
        }

        if (name.StartsWith("+"))
        {
            name = "Plus" + name.Substring(1);
        }

        if (name.StartsWith("_-"))
        {
            name = "__" + name.Substring(2);
        }
        
        return _invalidNameCharactersPattern.Replace(name
            .Replace(":", "-").Replace(@"""", @""), "_");
    }
}