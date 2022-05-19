using System.Dynamic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Newtonsoft.Json;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.CSharp.Models;
using NSwag.CodeGeneration.OperationNameGenerators;
using PluralizeService.Core;

const string adminUrl = @"https://shopify.dev/api/admin-rest";

var version = args[0];
version = string.IsNullOrWhiteSpace(version) ? "current" : version;

#region Main Menu
//Hidden in the documentation site is the json data for the navigation menu. Extract that and save so new sections can be quickly identified

var web = new HtmlWeb();
var doc = web.Load(adminUrl);
Console.WriteLine("Getting Main Menu");
var menuScript = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/script[2]");

var menuJson = menuScript.InnerText.Replace("//<![CDATA[", string.Empty).Replace("window.RailsData = ", string.Empty)
    .Replace("//]]>", string.Empty);
dynamic mainMenu = JsonConvert.DeserializeObject(menuJson.ReplaceLineEndings(string.Empty)) ??
                   throw new InvalidOperationException("No CDATA found for the main menu.");

SaveJsonFile(@"../../../menu.json", mainMenu);

#endregion Main Menu

if (mainMenu.api.rest_sidenav is null)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The main menu did not return anything or the structure has changed.");
    Console.ResetColor();
}
else
{
    #region Gather & Clean Specs
    //get psudo-OpenApi specs from the source of each sub page only for the current version
    var currentVersion = (string)mainMenu.api.current_stable_version;
    var rcVersion = (string)mainMenu.api.selectable_versions[1];
    var getVersion = version switch
    {
        "current" => currentVersion,
        "preview" => rcVersion,
        "rc" => rcVersion,
        _ => version
    }; 
    foreach (var mainMenuItem in mainMenu.api.rest_sidenav)
    {
        var section = (string)mainMenuItem.label;
        section = section.Replace(" ", string.Empty);
        foreach (var child in mainMenuItem.children)
        {
            var subSection = (string)child.label;
            if (subSection.Contains(" "))
                subSection = TitleCase(subSection);
            subSection = subSection.Replace(" ", string.Empty);
            Console.WriteLine($@"{section}/{subSection}.json");
            var url = $@"https://shopify.dev/api/admin-rest/{getVersion}/resources/{child.key}";
            var childDoc = web.Load(url);
            var childScript = childDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/script[2]");
            var childJson = childScript.InnerText.Replace("//<![CDATA[", string.Empty)
                .Replace("window.RailsData = ", string.Empty).Replace("//]]>", string.Empty)
                .Replace("#{api_version}", "{api_version}")
                .Replace("x-string", "string")
                ;
            
            dynamic childObject = JsonConvert.DeserializeObject(childJson) ??
                                  throw new InvalidOperationException("No CDATA returned.");
            var openApi = childObject.api.rest_resource;
            var path = $@"../../../{section}";
            CreateFoldersIfMissing(path);
            SaveJsonFile($@"{path}/{subSection}.json", openApi);

            var clean = CleanOpenApi(openApi);
            SaveJsonFile($@"{path}/{subSection}.clean.json", clean);
            await CreateController(JsonConvert.SerializeObject(clean), section, subSection);
        }
    }
    #endregion Gather & Clean Specs 
}

Console.WriteLine("Core Structure Downloaded. Press any key to continue.");

// Save json content formatted. This makes detecting changes easier.
void SaveJsonFile(string file, object? content) =>
    File.WriteAllText(file, JsonConvert.SerializeObject(content, Formatting.Indented, new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore
    }));

// Create any missing folders in a path.
void CreateFoldersIfMissing(string path)
{
    var folderExists = Directory.Exists(path);
    if (!folderExists)
    {
        Directory.CreateDirectory(path);
    }
}

// given a psudo-OpenApi spec from Shopify, make it valid version that can be used later
dynamic CleanOpenApi(dynamic openApi)
{
    dynamic clean = new ExpandoObject();
    clean.openapi = openApi.openapi;
    clean.info = new ExpandoObject();
    clean.info.title = openApi.info.title;
    clean.info.description = RemoveHtmlFromString((string)openApi.info.description) ?? string.Empty;
    clean.info.version = openApi.info.version;
    if (openApi.unsupported_version == true) return clean;
    clean.paths = new Dictionary<string, Dictionary<string, dynamic>>();
    foreach (var path in openApi.paths)
    {
        string pathKey = path.url;
        if (pathKey.IndexOf('?') > 0) 
            pathKey = pathKey.Substring(0, pathKey.IndexOf('?'));
        pathKey = pathKey.Replace("/admin/api/{api_version}", string.Empty);

        if (!clean.paths.ContainsKey(pathKey)) 
            clean.paths.Add(pathKey, new Dictionary<string, dynamic>());

        dynamic endpoint = new ExpandoObject();
        endpoint.description = RemoveHtmlFromString((string)path.description) ?? string.Empty;
        endpoint.summary = path.summary;
        endpoint.operationId = CreateOperationId((string)path.summary);
        var parameters = path.parameters;
        var pathParameters = new List<string>();
        foreach (var parameter in parameters)
        {
            if((string)parameter["in"] == "path")
                pathParameters.Add((string)parameter["name"]);
        }

        for (int i = 0; i < parameters.Count; i++)
        {
            var parameter = parameters[i];
            if ((string)parameter["in"] == "path" || !pathParameters.Contains((string)parameter["name"])) continue;

            //Console.WriteLine(parameter);
            parameters.RemoveAt(i);
            i--;
        }

        endpoint.parameters = parameters;

        endpoint.responses = path.responses;

        if(endpoint.operationId == "StoreCreditCardInTheCardVault") continue; //this calls an external service and should not be mapped.
        
        try
        {
            clean.paths[pathKey].Add((string)path.action, endpoint);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($@"{ex.Message} | {path.url}/{path.action}");
            Console.ResetColor();
        }
    }

    clean.components = new Dictionary<string, Dictionary<string, dynamic>>();
    clean.components.Add("schemas", new Dictionary<string, dynamic>());
    foreach (var component in openApi.components)
    {
        dynamic cleanComponent = new ExpandoObject();
        cleanComponent.type = component.type;
        if(component.description != null) cleanComponent.description = RemoveHtmlFromString((string)component.description) ?? string.Empty;
        var cleanProperties = new Dictionary<string, dynamic>();
            
        foreach (var property in component.properties)
        {
            dynamic cleanProperty = new ExpandoObject();
            if(property.id != null) cleanProperty.id = property.id;
            cleanProperty.type = property.type;
            if (property.description != null) cleanProperty.description = RemoveHtmlFromString((string)property.description) ?? string.Empty;
            if (property.example != null) cleanProperty.example = property.example;

            cleanProperties.Add((string) property.name, cleanProperty);
        }
        cleanComponent.properties = cleanProperties;

        //None of the models are correct. Don't bother moving them over.
        //clean.components["schemas"].Add((string)component.name, cleanComponent);
    }
    return clean;
}

//There is a ton of HTML in the spec. Get rid of it.
string? RemoveHtmlFromString(string? html)
{
    if (html == null) return null;
    const string removeHtmlTagPattern = "<[^>]*(>|$)";
    html = Regex.Replace(html, removeHtmlTagPattern, string.Empty);
    const string removeExtraSpacesPattern = $@"\n +";
    html = Regex.Replace(html, removeExtraSpacesPattern, "\n ");
    return html.Trim();
}

//Remove key words from a string that can be used to create a proper OperationId/Parameter name.
string CreateOperationId(string summary)
{
    summary = RemoveHtmlFromString(summary)!.Replace("-", " ").Replace("_", " ");
    summary = TitleCase(summary).Replace(" A ", " ")
        .Replace(" An ", " ")
        .Replace(" The ", " ")
        .Replace(" URL ", " Url ")
        .Trim()
        ;
    var split = summary.Split(' ');
    split[0] = PluralizationProvider.Singularize(split[0]);
    summary = string.Join(' ', split);
    var rgx = new Regex("[^a-zA-Z0-9]");
    summary = rgx.Replace(summary, "");
    return summary;
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
static string TitleCase(string input) => new (CharsToTitleCase(input).ToArray());

async Task CreateController(string openApi, string section, string controllerName)
{
    try
    {
        //convert the clean json to an OpenApiDocument.
        var document = OpenApiDocument.FromJsonAsync(openApi).Result;

        var controllerNamespace = controllerName == "AccessScope"
            ? "OpenShopify.OAuth.Builder.Controllers"
            : "OpenShopify.Admin.Builder.Controllers";
        var modelNamespace = controllerName == "AccessScope"
            ? "OpenShopify.OAuth.Builder.Models"
            : "OpenShopify.Admin.Builder.Models";
        var settings = new CSharpControllerGeneratorSettings()
        {
            ClassName = controllerName, OperationNameGenerator = new MultipleClientsFromFirstTagAndOperationIdGenerator(),
            GenerateClientInterfaces = true,
            GenerateOptionalParameters = true,
            AdditionalNamespaceUsages = new[] { "System.Text.Json" },
            ControllerTarget = CSharpControllerTarget.AspNetCore,
            //ControllerStyle = CSharpControllerStyle.Partial,
            ControllerStyle = CSharpControllerStyle.Abstract,
            ExcludedParameterNames = new[] { "api_version" }, // `api_version` is going to be hard-coded in the spec to make things easier.
            CodeGeneratorSettings =
            {
                GenerateDefaultValues  = false,
                SchemaType = SchemaType.OpenApi3,
            },
            CSharpGeneratorSettings =
            {
                Namespace = controllerNamespace,
                //Namespace = "OpenShopify.Admin.Builder.Delete",
                JsonLibrary = CSharpJsonLibrary.SystemTextJson,
                GenerateOptionalPropertiesAsNullable = true,
                GenerateNullableReferenceTypes = true,
                GenerateDefaultValues = false,
                GenerateDataAnnotations = true,
                PropertyNameGenerator = new CustomPropertyNameGenerator()
            }
        };

        var generator = new CSharpControllerGenerator(document, settings);
        var code = generator.GenerateFile();

        //default values can still get generated, remove them.
        code = code.Replace(" = \"any\"", string.Empty);
        code = code.Replace(" = \"50\"", string.Empty);
        code = code.Replace(" = 50", string.Empty);
        code = code.Replace(" = \"disabled_at DESC\"", string.Empty);
        code = code.Replace(" = \"last_order_date DESC\"", string.Empty);
        code = code.Replace(" = null", string.Empty);
        code = code.Replace(" = \"open\"", string.Empty);
        code = code.Replace(" = \"closed\"", string.Empty);
        code = code.Replace(" = \"other\"", string.Empty);
        code = code.Replace(" = \"false\"", string.Empty);
        code = code.Replace(" = \"true\"", string.Empty);
        code = code.Replace(" = false", string.Empty);
        code = code.Replace(" = true", string.Empty);
        code = code.Replace(" ?? \"false\"", " ?? false");
        code = code.Replace(" ?? \"true\"", " ?? true");
        code = code.Replace(" ?? \"50\"", " ?? 50");

        //all these parameters should be DateTime instead of object and string.
        var dateTimeParameters = new List<string>()
        {
            "created_at_max", "created_at_min", "date", "date_max", "date_min", "ends_at_max", "ends_at_min", "processed_at_max", "processed_at_min", "published_at_max", "published_at_min", 
            "starts_at_max", "starts_at_min", "updated_at_max", "updated_at_min"
        };
        code = ReplaceParameterTypes(code, dateTimeParameters,"object", "DateTime");
        code = ReplaceParameterTypes(code, dateTimeParameters, "string", "DateTime");

        //all these parameters should be long (id) instead of string.
        code = ReplaceParameterTypes(code,
            new List<string>()
            {
                "address_id", "application_charge_id", "application_credit_id", "article_id", "attribution_app_id", "batch_id", "blog_id", "carrier_service_id", "collect_id", 
                "collection_id", "collection_listing_id", "comment_id", "country_id", "custom_collection_id", "customer_id", "customer_saved_search_id", 
                "discount_code_id", "dispute_id", "draft_order_id", "event_id", "fulfillment_id", "fulfillment_order_id", "fulfillment_service_id", "gift_card_id", "image_id", 
                "inventory_item_id", "last_id", "location_id", "marketing_event_id", "metafield_id", "mobile_platform_application_id", "new_location_id", "order_id", "page_id", 
                "payment_id", "payout_id", "price_rule_id", "product_id", "product_listing_id", "province_id", "risk_id", "recurring_application_charge_id", "redirect_id", "refund_id",
                "report_id", "script_tag_id", "smart_collection_id", "storefront_access_token_id", "theme_id", "transaction_id", "usage_charge_id", "user_id", "variant_id", "webhook_id"
            },
            "string", "long");

        code = ReplaceParameterTypes(code,
            new List<string>()
            {
                "since_id", "limit"
            },
            "string", "int");

        code = ReplaceParameterTypes(code,
            new List<string>()
            {
                "disconnect_if_necessary", "in_shop_currency", "relocate_if_necessary"
            },
            "string", "bool");

        //The `page_info` parameter is not documented and is required for pagination. If a method has a `limit` parameter, it should have `page_info` as well.
        code = code.Replace("int? limit", "int? limit, string? page_info");
        code = code.Replace("int limit", "int? limit, string? page_info");
        code = code.Replace("limit ?? 50", "limit ?? 50, page_info");
        code = code.Replace("string? page_info, string? page_info", "string? page_info");
        code = code.Replace("page_info, page_info", "page_info");
        code = code.Replace("string? page_info, [Microsoft.AspNetCore.Mvc.FromQuery] string? page_info", "string? page_info");
        
        //Declare a new input parameter for POST and PUT methods.
        code = Regex.Replace(code, @"(Task Create\w+)\(", $@"$1([System.ComponentModel.DataAnnotations.Required] {modelNamespace}.Create{controllerName}Request request, ");
        code = Regex.Replace(code, @"(Task Update\w+)\(", $@"$1([System.ComponentModel.DataAnnotations.Required] {modelNamespace}.Update{controllerName}Request request, ");
        code = Regex.Replace(code, @"(Task Modify\w+)\(", $@"$1([System.ComponentModel.DataAnnotations.Required] {modelNamespace}.Update{controllerName}Request request, ");
        code = code.Replace(", )", ")");

        var path = $@"../../../../OpenShopify.Admin.Builder/Controllers";
        //var path = $@"../../../../OpenShopify.Admin.Builder/Delete";
        if(controllerName == "AccessScope")
            path = $@"../../../../OpenShopify.OAuth.Builder/Controllers";
        if (!string.IsNullOrWhiteSpace(section))
            path = Path.Combine(path, section);
        CreateFoldersIfMissing(path);
        path = Path.Combine(path, $@"{controllerName}Controller.cs");
        await File.WriteAllTextAsync(path, code);
        //await CreateExtendedControllerIfMissing(section, controllerName);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($@"{ex.Message} | {section}/{controllerName}");
        Console.ResetColor();
    }
}

string ReplaceParameterTypes(string code, List<string> parametersNames, string originalType, string newType)
{
    foreach (var parameter in parametersNames)
    {
        code = code.Replace($@"{originalType} {parameter}", $@"{newType} {parameter}");
        code = code.Replace($@"{originalType}? {parameter}", $@"{newType}? {parameter}");
    }

    return code;
}

async Task CreateExtendedControllerIfMissing(string section, string controllerName)
{
    var template = $@"using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.{section};

/// <inheritdoc />
[ApiGroup(ApiGroupNames.{section})]
[ApiController]
public class {controllerName}Controller : I{controllerName}Controller {{}}";
    
    var path = $@"../../../../OpenShopify.Admin.Builder/Controllers";
    if (controllerName == "AccessScope")
        path = $@"../../../../OpenShopify.OAuth.Builder/Controllers";
    if (!string.IsNullOrWhiteSpace(section))
        path = Path.Combine(path, section);
    CreateFoldersIfMissing(path);
    path = Path.Combine(path, $@"{controllerName}Controller.Extended.cs");
    if(!File.Exists(path))
        await File.WriteAllTextAsync(path, template);
}

internal class CustomPropertyNameGenerator : IPropertyNameGenerator
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
                .Replace("+", "plus"), true)
            .Replace("*", "Star")
            .Replace(":", "_")
            .Replace("-", "_")
            .Replace("#", "_");
}
