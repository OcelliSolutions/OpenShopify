using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class ProductListingController : ProductListingControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("product_listings.json")]
    public override Task GetProductListingsThatArePublishedToYourApp(long? collection_id, string? handle, int? limit, string? page_info,
        long? product_ids, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("product_listings/product_ids.json")]
    public override Task GetProductIdsThatArePublishedToYourApp(int? limit, string? page_info)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("product_listings/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountProductsThatArePublishedToYourApp()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("product_listings/{product_listing_id:long}.json")]
    public override Task GetSpecificProductListingThatIsPublishedToYourApp([Required] long product_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("product_listings/{product_listing_id:long}.json")]
    public override Task CreateProductListingToPublishProductToYourApp([Required] CreateProductListingRequest request, [Required] long product_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("product_listings/{product_listing_id:long}.json")]
    public override Task DeleteProductListingToUnpublishProductFromYourApp([Required] long product_listing_id)
    {
        throw new NotImplementedException();
    }
}
