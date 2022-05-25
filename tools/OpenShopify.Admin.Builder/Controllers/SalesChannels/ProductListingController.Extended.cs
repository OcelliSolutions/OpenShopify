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
    [ProducesResponseType(typeof(ProductListingList), StatusCodes.Status200OK)]
    public override Task GetProductListingsThatArePublishedToYourApp(long collection_id, string? handle = null, int? limit = null,
        string? page_info = null, string? product_ids = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("product_listings/product_ids.json")]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    public override Task GetProductIdsThatArePublishedToYourApp(int? limit = null, string? page_info = null)
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
    [ProducesResponseType(typeof(ProductListingItem), StatusCodes.Status200OK)]
    public override Task GetProductListingThatIsPublishedToYourApp([Required] long product_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("product_listings/{product_listing_id:long}.json")]
    [ProducesResponseType(typeof(ProductListingItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductListingError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateProductListingToPublishProductToYourApp([Required] CreateProductListingRequest request, [Required] long product_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("product_listings/{product_listing_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteProductListingToUnpublishProductFromYourApp([Required] long product_listing_id)
    {
        throw new NotImplementedException();
    }
}
