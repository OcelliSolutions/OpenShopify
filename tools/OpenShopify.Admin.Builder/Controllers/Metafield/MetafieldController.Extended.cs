using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Metafield;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.MetaField)]
[ApiController]
public class MetafieldController : MetafieldControllerBase
{
    public override Task RetrieveListOfMetafieldsFromTheResourcesEndpoint(string? created_at_max = null, string? created_at_min = null,
        string? fields = null, string? key = null, string? limit = "50", string? @namespace = null, string? since_id = null,
        string? type = null, string? updated_at_max = null, string? updated_at_min = null, string? value_type = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateMetafield()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfResourcesMetafields()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificMetafield(string metafield_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateMetafield(string metafield_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteMetafieldByItsID(string metafield_id)
    {
        throw new NotImplementedException();
    }
}