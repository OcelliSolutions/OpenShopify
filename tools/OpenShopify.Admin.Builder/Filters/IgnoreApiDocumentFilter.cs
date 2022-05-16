using Microsoft.OpenApi.Models;
using OpenShopify.Admin.Builder.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OpenShopify.Admin.Builder.Filters;

public class IgnoreApiDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var description in context.ApiDescriptions)
        {
            description.TryGetMethodInfo(out var info);
            var devAttributes = info.GetCustomAttributes(true).OfType<IgnoreApiAttribute>().Distinct();
            if (devAttributes.Any())
            {
                var keyPath = description.RelativePath;
                var removeRoutes = swaggerDoc.Paths.Where(x => x.Key.ToLower().Contains(keyPath.ToLower())).ToList();
                removeRoutes.ForEach(x => { swaggerDoc.Paths.Remove(x.Key); });
            }
        }
    }
}
