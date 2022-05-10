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
var web = new HtmlWeb();
var doc = web.Load(adminUrl);
Console.WriteLine("Getting Main Menu");
var menuScript = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/script[2]");

var menuJson = menuScript.InnerText.Replace("//<![CDATA[", string.Empty).Replace("window.RailsData = ", string.Empty)
    .Replace("//]]>", string.Empty);
dynamic mainMenu = JsonConvert.DeserializeObject(menuJson.ReplaceLineEndings(string.Empty)) ??
                   throw new InvalidOperationException("No CDATA found for the main menu.");

SaveFile(@"../../../menu.json", mainMenu);


if (mainMenu.api.rest_sidenav is null)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The main menu did not return anything or the structure has changed.");
    Console.ResetColor();
}
else
{
    var currentVersion = (string)mainMenu.api.current_stable_version;
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
            var url = $@"https://shopify.dev/api/admin-rest/{currentVersion}/resources/{child.key}";
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
            CreateIfMissing(path);
            SaveFile($@"{path}/{subSection}.json", openApi);

            var clean = CleanOpenApi(openApi);
            SaveFile($@"{path}/{subSection}.clean.json", clean);
            await CreateController(JsonConvert.SerializeObject(clean), currentVersion, section, subSection);
        }
    }
}

Console.WriteLine("Core Structure Downloaded. Press any key to continue.");

void SaveFile(string file, object? content) =>
    File.WriteAllText(file, JsonConvert.SerializeObject(content, Formatting.Indented, new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore
    }));

void CreateIfMissing(string path)
{
    var folderExists = Directory.Exists(path);
    if (!folderExists)
    {
        Directory.CreateDirectory(path);
    }
}

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

string? RemoveHtmlFromString(string? html)
{
    if (html == null) return null;
    const string removeHtmlTagPattern = "<[^>]*(>|$)";
    html = Regex.Replace(html, removeHtmlTagPattern, string.Empty);
    const string removeExtraSpacesPattern = $@"\n +";
    html = Regex.Replace(html, removeExtraSpacesPattern, "\n ");
    return html.Trim();
}

string CreateOperationId(string summary)
{
    summary = RemoveHtmlFromString(summary)!.Replace("-", " ").Replace("_", " ");
    summary = TitleCase(summary).Replace(" A ", " ")
        .Replace(" An ", " ")
        .Trim()
        ;
    var split = summary.Split(' ');
    split[0] = PluralizationProvider.Singularize(split[0]);
    summary = string.Join(' ', split);
    var rgx = new Regex("[^a-zA-Z0-9]");
    summary = rgx.Replace(summary, "");
    return summary;
}

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

async Task CreateController(string openApi, string version, string section, string controllerName)
{
    try
    {
        var document = OpenApiDocument.FromJsonAsync(openApi).Result;
        //controllerName = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(controllerName);
        var settings = new CSharpControllerGeneratorSettings()
        {
            ClassName = controllerName,
            OperationNameGenerator = new MultipleClientsFromFirstTagAndOperationIdGenerator(),
            GenerateClientInterfaces = true,
            GenerateOptionalParameters = true,
            AdditionalNamespaceUsages = new[] { "System.Text.Json" },
            ControllerTarget = CSharpControllerTarget.AspNetCore,
            ControllerStyle = CSharpControllerStyle.Abstract,
            ExcludedParameterNames = new[] { "api_version" },
            CSharpGeneratorSettings =
            {
                Namespace = "OpenShopify.Admin.Builder",
                JsonLibrary = CSharpJsonLibrary.SystemTextJson,
                GenerateOptionalPropertiesAsNullable = true,
                GenerateNullableReferenceTypes = true,
                GenerateDefaultValues = true,
                GenerateDataAnnotations = true,
                PropertyNameGenerator = new CustomPropertyNameGenerator()
            }
        };

        var generator = new CSharpControllerGenerator(document, settings);
        var code = generator.GenerateFile();
        var path = $@"../../../../OpenShopify.Admin.Builder/Controllers";
        if (!string.IsNullOrWhiteSpace(section))
            path = Path.Combine(path, section);
        CreateIfMissing(path);
        path = Path.Combine(path, $@"{controllerName}Controller.cs");
        await File.WriteAllTextAsync(path, code);
        await CreateExtendedControllerIfMissing(section, controllerName);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($@"{ex.Message} | {section}/{controllerName}");
        Console.ResetColor();
    }
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
public class {controllerName}Controller : {controllerName}ControllerBase {{}}";

    var path = $@"../../../../OpenShopify.Admin.Builder/Controllers";
    if (!string.IsNullOrWhiteSpace(section))
        path = Path.Combine(path, section);
    CreateIfMissing(path);
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
