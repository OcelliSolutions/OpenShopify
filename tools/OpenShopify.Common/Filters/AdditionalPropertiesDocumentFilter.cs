using Microsoft.OpenApi.Models;
using OpenShopify.Common.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OpenShopify.Common.Filters;

/// <summary>
///     Override the defaults for how swagger makes the file. Since we do not own it, we want to allow additional values.
///     This will be used in Integration Testing.
/// </summary>
public class AdditionalPropertiesDocumentFilter : IDocumentFilter
{
    /// <inheritdoc />
    public void Apply(OpenApiDocument openApiDoc, DocumentFilterContext context)
    {
        foreach (var (_, value) in context.SchemaRepository.Schemas
                     .Where(schema => schema.Value.AdditionalProperties == null && 
                                      schema.Key != nameof(ErrorResponse)))
        {
            value.AdditionalPropertiesAllowed = true;
            value.AdditionalProperties = new OpenApiSchema();
        }

        var objectPrefixExcludeAdditionalProperties = new List<string>()
        {
            "Create", "Update", "Send", "Accept", "Reject", "Move", "Apply", "Release", "Reschedule", "Cancel",
            "Calculate", "Complete", "PerformBulk", "Adjust", "Connect", "Set"
        };
        foreach (var (_, value) in context.SchemaRepository.Schemas.Where(schema => objectPrefixExcludeAdditionalProperties.Any(p => schema.Key.StartsWith(p))))
        {
            value.AdditionalPropertiesAllowed = false;
            value.AdditionalProperties = null;
        }
    }
}