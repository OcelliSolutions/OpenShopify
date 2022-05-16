using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class ProductListingController : IProductListingController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("product_listings.json")]
    public Task RetrieveProductListingsThatArePublishedToYourAppAsync(string? collection_id, string? handle, string limit,
        string? product_ids, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("product_listings/product_ids.json")]
    public Task RetrieveProductIdsThatArePublishedToYourAppAsync(string limit)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("product_listings/count.json")]
    public Task RetrieveCountOfProductsThatArePublishedToYourAppAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("product_listings/{product_listing_id}.json")]
    public Task RetrieveSpecificProductListingThatIsPublishedToYourAppAsync(string product_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("product_listings/{product_listing_id}.json")]
    public Task CreateProductListingToPublishProductToYourAppAsync(string product_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("product_listings/{product_listing_id}.json")]
    public Task DeleteProductListingToUnpublishProductFromYourAppAsync(string product_listing_id)
    {
        throw new NotImplementedException();
    }
}