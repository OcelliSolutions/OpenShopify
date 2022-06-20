using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OpenShopify.Common.Filters;
public class CommaSeparatedParameterOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        foreach (var parameter in operation.Parameters)
        {
            if (parameter.Schema.Type == "array")
            {
                parameter.Style = ParameterStyle.Form;
                parameter.Explode = false;
            }
        }
    }
}
