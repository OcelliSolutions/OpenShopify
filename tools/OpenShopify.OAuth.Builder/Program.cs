using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Common.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    //ensure all endpoints report that they only work with JSON and XML
    options.Filters.Clear();
    options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
    options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));
})
    .ConfigureApiBehaviorOptions(options =>
    {
        //MapClientErrors is a .NET6 feature that automatically wraps error responses if a structure is not specified. Shopify does not do this so it needs to be disabled.
        options.SuppressMapClientErrors = true;
    })
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(opt =>
{
    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

builder.Services.AddSwaggerGen(c =>
{
    c.SupportNonNullableReferenceTypes();
    //Skip (1) is because the first field-info of enum is a built-in int value
    typeof(ApiGroupNames).GetFields().Skip(1).ToList().ForEach(f =>
    {
        //Gets the attribute on the enumeration value
        var info = f.GetCustomAttributes(typeof(GroupInfoAttribute), false).OfType<GroupInfoAttribute>().FirstOrDefault();
        var serviceInfo = new OpenApiInfo() { Title = info?.Title, Version = info?.Version, Description = info?.Description };
        c.SwaggerDoc(f.Name, serviceInfo);
    });

    //Determine which group the interface belongs to
    c.DocInclusionPredicate((docName, apiDescription) =>
    {
        if (!apiDescription.TryGetMethodInfo(out var method)) return false;
        //1. All interfaces
        if (docName == "All") return true;
        //The value of reflection under the grouping characteristic of the controller
        var actionList = apiDescription.ActionDescriptor.EndpointMetadata.FirstOrDefault(x => x is ApiGroupAttribute);
        //2. Get the interface that has not been grouped***************
        if (docName == "NoGroup") return actionList == null;
        //3. Load the corresponding grouped interfaces
        if (actionList == null) return false;

        //Determine whether to include this group
        var actionFilter = actionList as ApiGroupAttribute;
        return actionFilter.GroupName.Any(x => x.ToString().Trim() == docName);
    });

    //Add authorization

    //Authentication mode, which is global add


    c.EnableAnnotations();
    c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"]}");
    c.AddServer(new OpenApiServer
    {
        Url = "https://{store_name}.myshopify.com",
        Variables = new Dictionary<string, OpenApiServerVariable>(new List<KeyValuePair<string, OpenApiServerVariable>>()
        {
            new("store_name", new OpenApiServerVariable(){Default = "{{store_name}}", Description = "The sub-domain of the storefront."})
        })
    });

    c.DocumentFilter<AdditionalPropertiesDocumentFilter>();
    c.DocumentFilter<IgnoreApiDocumentFilter>();
    c.OperationFilter<ResponseHeadersFilter>();
    c.SchemaFilter<DescribeEnumMemberValues>();
    c.AddSecurityDefinition("ApiKey",
        new OpenApiSecurityScheme
        {
            Name = "X-Shopify-Access-Token",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "ApiKeyScheme",
            In = ParameterLocation.Header
        });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            // add the Authenticate button to show on the SwaggerUI
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "ApiKey" },
                In = ParameterLocation.Header
            },
            Array.Empty<string>()
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, true);
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.Use((context, next) =>
    {
        context.Response.Headers["Access-Control-Allow-Origin"] = "*";
        return next.Invoke();
    });

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger";

        //Skip (1) is because the first field-info of enum is a built-in int value
        typeof(ApiGroupNames).GetFields().Skip(1).ToList().ForEach(f =>
        {
            //Gets the attribute on the enumeration value
            var info = f.GetCustomAttributes(typeof(GroupInfoAttribute), false).OfType<GroupInfoAttribute>().FirstOrDefault();
            c.SwaggerEndpoint($"/swagger/{f.Name}/swagger.json", info != null ? info.Title : f.Name);
        });
    });

}

app.Run();
