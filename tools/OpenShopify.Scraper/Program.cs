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
using PluralizationService.Core.Builder.Base;
using PluralizeService.Core;
using JsonSerializer = System.Text.Json.JsonSerializer;

dynamic GetMainMenu(string url)
{
    //Hidden in the documentation site is the json data for the navigation menu. Extract that and save so new sections can be quickly identified

    var web = new HtmlWeb();
    var doc = web.Load(url);
    Console.WriteLine("Getting Main Menu");
    var menuScript = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/script[2]");

    var menuJson = menuScript.InnerText.Replace("//<![CDATA[", string.Empty).Replace("window.RailsData = ", string.Empty)
        .Replace("//]]>", string.Empty);
    dynamic mainMenu = JsonConvert.DeserializeObject(menuJson.ReplaceLineEndings(string.Empty)) ??
                       throw new InvalidOperationException("No CDATA found for the main menu.");

    return mainMenu;
}

const string adminUrl = @"https://shopify.dev/api/admin-rest";

var version = args[0];
version = string.IsNullOrWhiteSpace(version) ? "current" : version;
var download = false;
if(args.Length > 1)
    download = args[1] == "download";

#region Main Menu

var mainMenu = GetMainMenu(adminUrl);
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
    //get pseudo-OpenApi specs from the source of each sub page only for the current version
    var currentVersion = (string)mainMenu.api.current_stable_version;
    var rcVersion = (string)mainMenu.api.selectable_versions[1];
    var getVersion = version switch
    {
        "current" => currentVersion,
        "preview" => rcVersion,
        "rc" => rcVersion,
        _ => version
    };
    var web = new HtmlWeb();
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
            var path = $@"../../../{section}";
            var savePath = $@"{path}/{subSection}.json";
            dynamic openApi;
            if (download)
            {
                var childDoc = web.Load(url);
                var childScript = childDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/script[2]");
                var childJson = childScript.InnerText.Replace("//<![CDATA[", string.Empty)
                        .Replace("window.RailsData = ", string.Empty).Replace("//]]>", string.Empty)
                        .Replace("#{api_version}", "{api_version}")
                        .Replace("x-string", "string")
                    ;

                dynamic childObject = JsonConvert.DeserializeObject(childJson) ??
                                      throw new InvalidOperationException("No CDATA returned.");
                openApi = childObject.api.rest_resource;
                CreateFoldersIfMissing(path);
                SaveJsonFile(savePath, openApi);
            }
            else
            {
                var content = File.ReadAllText(savePath);
                openApi = JsonConvert.DeserializeObject(content) ?? throw new InvalidOperationException("No content found.");
            }

            //var clean = CleanOpenApi(openApi);
            if (openApi != null)
            {
                var clean = ConvertToOpenApiDocument(openApi);
                SaveJsonFile($@"{path}/{subSection}.clean.json", clean);
                await CreateController(clean, section, subSection);
            }
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

OpenApiDocument ConvertToOpenApiDocument(dynamic openApi)
{
    if (openApi == null) return new OpenApiDocument();
    //create the main document header.
    var clean = new OpenApiDocument
    {
        Info =
        {
            Version = openApi.info.version,
            Title = openApi.info.title,
            Description = HtmlToMarkdown((string)openApi.info.description)
        }
    };
    if (openApi.unsupported_version == true) return clean;

    // Servers are added later depending on the paths given
    var hasDefaultRoute = false;
    var hasOAuthRoute = false;
    foreach (var path in openApi.paths)
    {
        // Get the path. Multiple operations (GET, POST, PUT, and DELETE) can share a path.
        string pathKey = path.url;
        if (pathKey.IndexOf('?') > 0)
            pathKey = pathKey.Substring(0, pathKey.IndexOf('?'));
        
        if (pathKey.Contains("/admin/api/{api_version}"))
        {
            hasDefaultRoute = true;
            pathKey = pathKey.Replace("/admin/api/{api_version}", string.Empty);
        }

        if (pathKey.Contains("/admin/oauth"))
        {
            hasOAuthRoute = true;
            pathKey = pathKey.Replace("/admin", string.Empty);
        }

        //add the path if it has not been added yet
        if (!clean.Paths.ContainsKey(pathKey))
            clean.Paths.Add(pathKey, new OpenApiPathItem());

        // Create the endpoint (GET, POST, PUT, and DELETE)
        var endpoint = new OpenApiOperation
        {
            Description = HtmlToMarkdown((string)path.description),
            Summary = path.summary,
            OperationId = CreateOperationId((string)path.summary)
        };

        // add the input parameters
        var hasLimit = false;
        var hasPageInfo = false;
        var requiredId = true;

        var longParameters = new List<string>()
        {
            "address_id", "application_charge_id", "application_credit_id", "article_id", "attribution_app_id", "batch_id", "blog_id", "carrier_service_id", "collect_id",
            "collection_id", "collection_listing_id", "comment_id", "country_id", "custom_collection_id", "customer_id", "customer_saved_search_id",
            "discount_code_id", "dispute_id", "draft_order_id", "event_id", "fulfillment_id", "fulfillment_order_id", "fulfillment_service_id", "gift_card_id", "image_id",
            "inventory_item_id", "last_id", "location_id", "marketing_event_id", "metafield_id", "mobile_platform_application_id", "new_location_id", "order_id", "page_id",
            "payment_id", "payout_id", "price_rule_id", "product_id", "product_listing_id", "province_id", "risk_id", "recurring_application_charge_id", "redirect_id", "refund_id",
            "report_id", "script_tag_id", "smart_collection_id", "storefront_access_token_id", "theme_id", "transaction_id", "usage_charge_id", "user_id", "variant_id", "webhook_id", "since_id"
        };

        var intParameters =
            new List<string>()
            {
                "limit", "offset"
            };

        var boolParameters = new List<string>()
        {
            "disconnect_if_necessary", "in_shop_currency", "relocate_if_necessary", "use_customer_default_address", "email", "restock"
        };

        var stringParameters = new List<string>()
        {
            "fields", "messages"
        };

        var longListParameters = new List<string>()
        {
            "ids"
        };

        var requiredParameters = new List<string>()
        {
            "token"
        };

        var ignoreParameters = new List<string>()
        {
            "new_location_id"
        };
        foreach (var parameter in path.parameters)
        {
            // `api_version` is a server variables, not a path variable.
            if(parameter.name == "api_version") continue;

            //if this is a PUT or POST endpoint and the parameter is not in the route, ignore it. It will be passed in the body.
            if (path.action.ToString().ToLower() == "post" || path.action.ToString().ToLower() == "put")
                if(!pathKey.Contains( string.Concat("{", parameter.name, "}")))
                    continue;

            /*
            if(!((string)parameter.name).EndsWith("_id"))
                if((path.action.ToString().ToLower() == "post" || path.action.ToString().ToLower() == "put") && 
                   !requiredParameters.Contains((string)parameter.name))
                    continue;

            if (ignoreParameters.Contains((string)parameter.name))
                continue;
            */

            if (parameter.name == "limit") hasLimit = true;
            if (parameter.name == "page_info") hasPageInfo = true;
            
            var schema = GetSchema((string)parameter.name);
            schema.Description = HtmlToMarkdown(parameter.description);

            if (longParameters.Contains((string)parameter.name))
            {
                schema.Type = JsonObjectType.Integer;
                schema.Format = "int64";
            }
            else if (intParameters.Contains((string)parameter.name))
            {
                schema.Type = JsonObjectType.Integer;
                schema.Format = "int32";
            }
            else if (boolParameters.Contains((string)parameter.name))
            {
                schema.Type = JsonObjectType.Boolean;
                schema.Format = null;
            }
            else if (stringParameters.Contains((string)parameter.name))
            {
                schema.Type = JsonObjectType.String;
                schema.Format = null;
            }
            else if (longListParameters.Contains((string)parameter.name))
            {
                schema.Type = JsonObjectType.Array;
                schema.Item = new JsonSchema() { Type = JsonObjectType.Integer, Format = "int64"};
            }

            // consecutive starting *id parameters are required, all others are optional.
            if (((string)parameter.name).EndsWith("_id") && requiredId) requiredId = true;
            else requiredId = false;

            if (endpoint.OperationId.StartsWith("Count"))
                requiredId = false;

            var isRequired = longParameters.Contains((string)parameter.name) && requiredId;
            isRequired = requiredParameters.Contains((string)parameter.name) || requiredId;

            if (parameter.name == "since_id" || parameter.name == "last_id")
                isRequired = false;
            
            schema.Default = parameter.schema["default"];
            if (parameter.schema["enum"] is not null)
            {
                foreach (var e in parameter.schema["enum"])
                {
                    schema.EnumerationNames.Add((string)e);
                }
            }

            var openApiParameter = new OpenApiParameter()
            {
                Name = parameter.name,
                Description = HtmlToMarkdown(parameter.description),
                Schema = schema,
                IsRequired = isRequired,
                IsDeprecated = parameter.deprecated ?? false,
                Kind = parameter["in"] switch
                {
                    "path" => OpenApiParameterKind.Path,
                    "query" => OpenApiParameterKind.Query,
                    "body" => OpenApiParameterKind.Body,
                    "header" => OpenApiParameterKind.Header,
                    _ => OpenApiParameterKind.Query
                }
            };
            if (pathKey.Contains(string.Concat("{", parameter.name, "}")))
                openApiParameter.Kind = OpenApiParameterKind.Path;  

            endpoint.Parameters.Add(openApiParameter);
        }
        //many times the given spec does not explicitly add `page_info` for paginated endpoints. Add it.
        if (hasLimit && !hasPageInfo)
        {
            var limit = endpoint.Parameters.First(p => p.Name == "limit");
            var index = endpoint.Parameters.IndexOf(limit);

            endpoint.Parameters.Insert(index+1, new OpenApiParameter()
            {
                Name = "page_info",
                Description = "A unique ID used to access a certain page of results.",
                Schema = new() { Type = JsonObjectType.String },
                IsRequired = false
            });
        }

        try
        {
            clean.Paths[pathKey].Add((string)path.action, endpoint);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($@"{ex.Message} | {path.url}/{path.action}");
            Console.ResetColor();
        }
    }

    foreach (var component in openApi.components)
    {
        var cleanComponent = new JsonSchema
        {
            Id = component.name,
            Type = JsonObjectType.Object,
            Description = HtmlToMarkdown(component.description),
            Title = component.title
        };

        var hasId = false;
        foreach (var property in component.properties)
        {
            //remove all the `id` properties. These will be manually added later
            if (property.name == "id")
            {
                hasId = true;
                continue;
            }
            //remove all the `created_at` and `updated_at` properties. These will be manually added later
            if (property.name == "created_at" || property.name == "updated_at")
                continue;
            var schema = GetSchema((string)property.name);

            var cleanProperty = new JsonSchemaProperty
            {
                Id = property.id,
                Type = schema.Type,
                Description = HtmlToMarkdown(property.description),
                Format = schema.Format,
                Item = schema.Item,
                IsRequired = property.required ?? false,
                IsReadOnly = property.readOnly ?? false,
                Example = property.example, 
                IsDeprecated = property.deprecated ?? false
            };
            cleanComponent.Properties.Add((string)property.name, cleanProperty);
        }
        if(!hasId)
            Console.WriteLine($@"  * No ID: {cleanComponent.Id}Orig");

        clean.Components.Schemas.Add($@"{cleanComponent.Id}Orig", cleanComponent);
    }
    /*
    //add the servers
        if (hasDefaultRoute)
        clean.Servers.Add(
            new OpenApiServer()
            {
                Url = "https://{store_name}.myshopify.com/admin/api/{api_version}",
                Variables =
                {
                    new KeyValuePair<string, OpenApiServerVariable>("store_name",
                        new OpenApiServerVariable()
                        {
                            Default = "{{store_name}}", Description = "The sub-domain of the storefront."
                        }),
                    new KeyValuePair<string, OpenApiServerVariable>("api_version",
                        new OpenApiServerVariable()
                        {
                            Default = openApi.info.version, Description = "The api version."
                        })
                }
            });
    if(hasOAuthRoute)
        clean.Servers.Add(new OpenApiServer()
        {
            Url = "https://{store_name}.myshopify.com",
            Variables =
            {
                new KeyValuePair<string, OpenApiServerVariable>("store_name",
                    new OpenApiServerVariable()
                    {
                        Default = "{{store_name}}", Description = "The sub-domain of the storefront."
                    })
            }
        });
    */

    return clean;
}

JsonSchema GetSchema(string propertyName)
{
    var dateTimeProperties = new List<string>()
    {
        "created_at_max", "created_at_min", "ends_at_max", "ends_at_min",
        "processed_at_max", "processed_at_min", "published_at_max", "published_at_min", "starts_at_max",
        "starts_at_min", "updated_at_max", "updated_at_min", "updated_at", "updated_at", "starts_at",
        "ends_at", "created_at", "closed_at", "published_at", "accepts_marketing_updated_at",
        "invoice_sent_at", "completed_at", "happened_at", "estimated_delivery_at", "fulfill_at",
        "disabled_at", "expires_on", "cancelled_at", "processed_at", "billing_on", "activated_on",
        "cancelled_on", "trial_ends_on", "feedback_generated_at", "started_at", "scheduled_to_end_at", 
        "ended_at"
    };
    var dateProperties = new List<string>()
    {
        "date", "date_max", "date_min"
    };
    var longProperties = new List<string>()
    {
        "usage_limit"
    };
    var intProperties = new List<string>()
    {
        "position", "orders_count", "number", "order_number", "trial_days", "times_used", "times_used_max", "times_used_min",
        "usage_count"
    };
    var boolProperties = new List<string>()
    {
        "once_per_customer", "test", "published", "active", "service_discovery", "buyer_accepts_marketing",
        "taxes_included", "featured", "enabled", "accepts_marketing", "verified_email", "tax_exempt",
        "notify_customer", "requires_shipping_method", "TrackingSupport",
        "include_pending_stock", "fulfillment_orders_opt_in", "tracked", "requires_shipping", "legacy",
        "estimated_taxes", "cause_cancel", "display", "taxable", "multi_location_enabled", "password_enabled",
        "tax_shipping", "county_taxes", "has_storefront", "setup_required", "disjunctive", "previewable",
        "processing", "account_owner", "receive_announcements", "tracking_support",
        "confirmed", "cache", "paid", "enabled_universal_or_app_links", "enabled_shared_webcredentials",
        "has_discounts", "has_gift_cards", "eligible_for_payments", "requires_extra_payments_agreement",
        "password_enabled","has_storefront","eligible_for_card_reader_giveaway","finances",
        "checkout_api_supported","multi_location_enabled","setup_required","pre_launch_enabled", "notify_merchant"

    };
    var decimalProperties = new List<string>()
    {
        "price", "amount", "latitude", "longitude", "subtotal_price", "total_discounts", "total_duties",
        "total_line_items_price", "total_price", "total_tax", "total_weight", "tax", "total_spent", "balance",
        "initial_value", "cost", "total_tip_received", "score", "compare_at_price", "weight",
        "size", "grams", "height", "width", "inventory_quantity", "tax_percentage", "maximum_refundable",
        "old_inventory_quantity", "total_price_usd"
    };
    var stringProperties = new List<string>()
    {
        "admin_graphql_api_id", "remote_id", "application_id"
    };
    var longListProperties = new List<string>()
    {
        "entitled_product_ids", "prerequisite_saved_search_ids", "prerequisite_customer_ids", "entitles_variant_ids",
        "entitles_collection_ids", "entitles_country_ids", "prerequisite_product_ids", "prerequisite_variant_ids",
        "prerequisite_collection_ids", "customer_segment_prerequisite_ids", "variant_ids", "entitled_variant_ids",
        "entitled_country_ids", "entitled_collection_ids", "ids" 
    };
    var stringListProperties = new List<string>()
    {
        "arguments", "tax_exemptions", "tracking_numbers", "tracking_urls", "supported_actions", 
        "payment_gateway_names", "enabled_presentment_currencies", "permissions", "fields",
        "metafield_namespaces", "private_metafield_namespaces", "fulfillment_holds", "messages",
        "sha256_cert_fingerprints"
    };
    var objectListProperties = new List<string>()
    {
        "arguments"
    };
    var schema = new JsonSchema(){Type = JsonObjectType.String};
    if (stringProperties.Contains(propertyName)) schema = new() { Type = JsonObjectType.String };
    else if (propertyName == "id" || propertyName.EndsWith("_id")) schema = new() { Type = JsonObjectType.Integer, Format = "int64"};
    else if (dateTimeProperties.Contains(propertyName)) schema = new(){ Type = JsonObjectType.String, Format = "date-time"};
    else if (dateProperties.Contains(propertyName)) schema = new() { Type = JsonObjectType.String, Format = "date", Pattern = "/([0-9]{4})-(?:[0-9]{2})-([0-9]{2})/" };
    else if (longProperties.Contains(propertyName)) schema = new() { Type = JsonObjectType.Integer, Format = "int64"};
    else if (intProperties.Contains(propertyName)) schema = new() { Type = JsonObjectType.Integer, Format = "int32"};
    else if (boolProperties.Contains(propertyName)) schema = new() { Type = JsonObjectType.Boolean};
    else if (decimalProperties.Contains(propertyName)) schema = new() { Type = JsonObjectType.Number, Format = "decimal"};

    else if (longListProperties.Contains(propertyName))
    {
        schema = new()
        {
            Type = JsonObjectType.Array, 
            Item = new JsonSchema() { Type = JsonObjectType.Integer, Format = "int64" }
        };
    }
    else if (stringListProperties.Contains(propertyName))
    {
        schema = new()
        {
            Type = JsonObjectType.Array,
            Item = new JsonSchema() { Type = JsonObjectType.String }
        };
    }
    if (objectListProperties.Contains(propertyName))
    {
        schema = new()
        {
            Type = JsonObjectType.Array,
            Item = new JsonSchema() { Type = JsonObjectType.Object }
        };
    }
    return schema;
}

//There is a ton of HTML in the spec. Get rid of it.
string? RemoveHtmlFromString(string? html)
{
    if (html == null) return null;
    const string removeHtmlTagPattern = "<[^>]*(>|$)";
    html = Regex.Replace(html, removeHtmlTagPattern, string.Empty);
    const string removeExtraSpacesPattern = @"\n +";
    html = Regex.Replace(html, removeExtraSpacesPattern, "\n ");
    return html.Trim();
}

string? HtmlToMarkdown(string? html)
{
    if (string.IsNullOrWhiteSpace(html)) return null;
   
    html = html.Replace("\r", "")
        .Replace("\n", "")
        .Trim();
    html = Regex.Replace(html, $@"\s+", " ");
    var markdown = string.IsNullOrWhiteSpace(html) ? null : new Html2Markdown.Converter().Convert(html);
    return markdown?.Replace("<br />", "")
        .Replace("<br/>", "");
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

    summary = summary
        .Replace("ReturnedBy", "By")
        .Replace("Receive", "Get")
        .Replace("Retrieve", "Get")
        .Replace("Return", "Get")
        .Replace("Modify", "Update")
        .Replace("Remove", "Delete")
        .Replace("CreateNew", "Create")
        .Replace("UpdateExisting", "Update")
        .Replace("GetListOfAll", "List")
        .Replace("GetListOf", "List")
        .Replace("GetAllOf", "List")
        .Replace("GetAll", "List")
        .Replace("ListAllOf", "List")
        .Replace("GetDetailsForSingle", "Get")
        .Replace("GetSingle", "Get")
        .Replace("GetSpecific", "Get")
        .Replace("GetCountOfAll", "Count")
        .Replace("GetOrderCount", "CountOrders")
        .Replace("GetCountOf", "Count")
        .Replace("DeleteExisting", "Delete")
        .Replace("ForArticle", "")
        .Replace("OfArticle", "")
        .Replace("FromBlog", "")
        .Replace("ForBlog", "")
        .Replace("OfBlog", "")
        .Replace("ForOrder", "")
        .Replace("OfOrder", "")
        .Replace("ForCountry", "")
        .Replace("ThatArePublishedToYourApp", "")
        .Replace("ThatIsPublishedToYourApp", "")
        .Replace("ToPublishCollectionToYourApp", "")
        .Replace("ToPublishProductToYourApp","")
        .Replace("ToUnpublishCollectionFromYourApp", "")
        .Replace("ToUnpublishProductFromYourApp", "")
        .Replace("WithStatusOPEN","")
        .Replace("ByItsID", "")
        .Replace("ByID", "");

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

async Task CreateController(OpenApiDocument document, string section, string controllerName)
{
    try
    {
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
            ControllerStyle = CSharpControllerStyle.Abstract,
            //AdditionalContractNamespaceUsages = new []{modelNamespace},
            ExcludedParameterNames = new[] { "api_version" }, // `api_version` is going to be hard-coded in the spec to make things easier.
            CodeGeneratorSettings =
            {
                SchemaType = SchemaType.OpenApi3
            },
            CSharpGeneratorSettings =
            {
                Namespace = modelNamespace,
                //Namespace = "OpenShopify.Admin.Builder.Delete",
                JsonLibrary = CSharpJsonLibrary.SystemTextJson,
                GenerateOptionalPropertiesAsNullable = true,
                GenerateNullableReferenceTypes = true,
                GenerateDefaultValues = true,
                GenerateDataAnnotations = true,
                GenerateNativeRecords = true, DateType = "DateTime",
                //HandleReferences = true,
                PropertyNameGenerator = new CustomPropertyNameGenerator()
            }
        };

        var generator = new CSharpControllerGenerator(document, settings);
        var code = generator.GenerateFile();
        
        //Declare a new input parameter for POST and PUT methods.
        var keyWords = new List<string>()
        {
            "Create", "Update", "Send", "Accept", "Reject", "Move", "Apply", "Release", "Reschedule", "Cancel",
            "Calculate", "Complete", "PerformBulk", "Adjust", "Connect", "Set"
        };
        foreach (var keyWord in keyWords)
        {
            code = Regex.Replace(code, $@"Task ({keyWord}\w+)\(", $@"Task $1([System.ComponentModel.DataAnnotations.Required] {modelNamespace}.$1Request request, ");
        }

        code = code.Replace(", )", ")")
            .Replace("<br/>", "")
            .Replace("<br />", "");
        var path = @"../../../../OpenShopify.Admin.Builder/Controllers";
        //var path = $@"../../../../OpenShopify.Admin.Builder/Delete";
        if(controllerName == "AccessScope")
            path = @"../../../../OpenShopify.OAuth.Builder/Controllers";
        if (!string.IsNullOrWhiteSpace(section))
            path = Path.Combine(path, section);
        CreateFoldersIfMissing(path);
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
    var template = $@"using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.{section};

/// <inheritdoc />
[ApiGroup(ApiGroupNames.{section})]
[ApiController]
public class {controllerName}Controller : {controllerName}ControllerOrig {{}}";
    
    var path = @"../../../../OpenShopify.Admin.Builder/Controllers";
    if (controllerName == "AccessScope")
        path = @"../../../../OpenShopify.OAuth.Builder/Controllers";
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
        TitleCase(ConversionUtilities.ConvertToUpperCamelCase(property.Name
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
            .Replace("#", "_")
            .Replace("_", " "))
            .Replace(" ", "");


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

