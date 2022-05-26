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
    var className = shopifyFile[shopifyFile.IndexOf("open-shopify-", StringComparison.Ordinal)..];
    className = className.Replace("open-shopify-", string.Empty).Replace(".yaml", string.Empty);
    className = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(className).Replace("-", string.Empty);
    var document = OpenApiYamlDocument.FromFileAsync(shopifyFile).Result;
    
    var excludeNamesForClient = new List<string> { "ErrorResponse", "ShopifyResponse", "CountItem" };
    if (className != "Metafield")
        excludeNamesForClient.AddRange(new List<string>
        {
            "Metafield", "MetafieldType"
        });
    switch (className)
    {
        case "DiscountCode":
            excludeNamesForClient.AddRange(new List<string> { "Address", "ClientDetails" });
            break;
        case "Customers":
            excludeNamesForClient.AddRange(new List<string>
            {
                "LineItemProperty", "OrderMetafield", "NoteAttribute", "LineItemOriginLocation", "LineItemDuty", 
                "LineItem", "Fulfillment", "DiscountCode", "DiscountApplication", "DiscountAllocation", "PaymentDetails",
                "Price", "PriceSet", "Refund", "RefundDuty", "RefundDutyType", "RefundLineItem", "RefundLineItem",
                "RefundOrderAdjustment", "Shipping", "ShippingLine", "TaxLine", "Transaction", "CurrencyExchangeAdjustment",
                "Order", "OrderList", "CancelReason", "FinancialStatus", "FulfillmentStatus", "ProcessingMethod",
                "TransactionErrorCode", "TransactionKind", "ExtendedAuthorizationAttributes", "PaymentsRefundAttributeStatus",
                "PaymentsRefundAttributes"
            });
            break;
        case "Orders":
            excludeNamesForClient.AddRange(new List<string>
            {
                "Address", "ClientDetails", "Customer", "CustomerAddress","EmailMarketingConsent", "SmsMarketingConsent", 
                "CustomerMetafield", "DiscountCode", "Price", "Fulfillment"
            });
            break;
        case "SalesChannels":
            excludeNamesForClient.AddRange(new List<string>
            {
                "Address", "Customer", "CustomerAddress", "EmailMarketingConsent", "SmsMarketingConsent", 
                "CustomerMetafield", "DiscountAllocation", "DiscountCode", "LineItem", "LineItemDuty", 
                "LineItemOriginLocation", "LineItemProperty", "Price", "PriceSet", "ShippingLine", "TaxLine",
                "ProductImage", "Product", "PresentmentPrice", "ProductList", "ProductOption", "ProductVariant",
                "Checkout", "CheckoutLineItem", "Transaction", "TransactionItem", "TransactionList"
            });
            break;
        case "ShopifyPayments":
            excludeNamesForClient.AddRange(new List<string>
            {
                "TransactionList", "TransactionItem", "Transaction", "CurrencyExchangeAdjustment", "PaymentDetails",
                "TransactionErrorCode", "TransactionKind", "ExtendedAuthorizationAttributes", "PaymentsRefundAttributeStatus",
                "PaymentsRefundAttributes"
            });
            break;
        case "ShippingAndFulfillment":
            excludeNamesForClient.AddRange(new List<string>
            {
                "Address", "CustomerAddress", "EmailMarketingConsent", "SmsMarketingConsent", "LineItem", "LineItemDuty", 
                "LineItemOriginLocation", "LineItemProperty", "DiscountAllocation", "Price", "PriceSet", "TaxLine"
            });
            break;
    }

    var excludedNames = excludeNamesForClient.ToArray();
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
        WrapResponses = true, 
        ResponseClass = "ShopifyResponse", 
        ExcludedParameterNames = new []{"api_version"},
        CSharpGeneratorSettings =
        {
            Namespace = @"Ocelli.OpenShopify", 
            EnumNameGenerator = new CustomEnumNameGenerator(),
            JsonLibrary = CSharpJsonLibrary.SystemTextJson,
            GenerateOptionalPropertiesAsNullable = true,
            GenerateNullableReferenceTypes = true,
            GenerateDefaultValues = true,
            GenerateDataAnnotations = true, 
            ExcludedTypeNames = excludedNames,
            PropertyNameGenerator = new CustomPropertyNameGenerator()
        }
    };

    var generator = new CSharpClientGenerator(document, settings);
    var code = generator.GenerateFile();
    code = code.Replace("JsonStringEnumConverter", "JsonStringEnumMemberConverter");

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
    private readonly static Regex InvalidNameCharactersPattern = new(@"[^\p{Lu}\p{Ll}\p{Lt}\p{Lm}\p{Lo}\p{Nl}\p{Mn}\p{Mc}\p{Nd}\p{Pc}\p{Cf}]");

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
            name = $"Minus{name.Substring(1)}";
        }

        if (name.StartsWith("+"))
        {
            name = "Plus" + name.Substring(1);
        }

        if (name.StartsWith("_-"))
        {
            name = "__" + name.Substring(2);
        }
        
        var s = InvalidNameCharactersPattern.Replace(name
            .Replace(":", "-").Replace(@"""", @""), "_");
        return TitleCase(s.Replace("_", " ")).Replace(" ", "");
    }
    // convert a string to title case.
    static IEnumerable<char> CharsToTitleCase(string s)
    {
        var newWord = true;
        foreach (var c in s)
        {
            if (newWord) { yield return char.ToUpper(c); newWord = false; }
            else yield return c;
            if (c == ' ') newWord = true;
        }
    }

    //static string TitleCase(string input) => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input);
    static string TitleCase(string input) => new(CharsToTitleCase(input).ToArray());
}

