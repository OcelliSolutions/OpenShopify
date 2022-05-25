using Microsoft.OpenApi.Models;
using OpenShopify.Common.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OpenShopify.Common.Filters;

public class ResponseHeadersFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Get all response header declarations for a given operation
        var actionResponsesWithHeaders = context.ApiDescription.CustomAttributes()
            .OfType<ProducesResponseHeaderAttribute>()
            .ToArray();

        //if (!actionResponsesWithHeaders.Any())
        //    return;

        foreach (var responseCode in operation.Responses.Keys)
        {
            // Do we have one or more headers for the specific response code
            var responseHeaders = actionResponsesWithHeaders.Where(resp => resp.StatusCode.ToString() == responseCode);
            //if (!responseHeaders.Any())
            //    continue;

            var response = operation.Responses[responseCode];
            response.Headers ??= new Dictionary<string, OpenApiHeader>();

            foreach (var responseHeader in responseHeaders)
            {
                response.Headers[responseHeader.Name] = new OpenApiHeader
                {
                    Schema = new OpenApiSchema { Type = responseHeader.Type.ToString() },
                    Description = responseHeader.Description, 
                };
            }

            if (operation.OperationId.StartsWith("List"))
                response.Headers["Link"] = new OpenApiHeader
                {
                    Schema = new OpenApiSchema { Type = "string" },
                    Description = "The link header includes a `rel` parameter, where `relation-types` describes the relation of the linked page to the current page of results. The value can either be `previous` or `next`. If your initial request doesn't return enough records to generate an additional page of results, then the response won't have a link header."
                };
            response.Headers["X-Shopify-Shop-Api-Call-Limit"] = new OpenApiHeader
            {
                Schema = new OpenApiSchema { Type = "string" },
                Description = "How many requests you’ve made for a particular store"
            };
            response.Headers["Retry-After"] = new OpenApiHeader
            {
                Schema = new OpenApiSchema { Type = "string" },
                Description = "Contains the number of seconds to wait until you can make a request again."
            };
        }
    }
}
