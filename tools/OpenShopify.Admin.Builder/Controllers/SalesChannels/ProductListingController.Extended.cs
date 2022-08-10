using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class ProductListingController : ProductListingControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("product_listings.json")]
    [ProducesResponseType(typeof(ProductListingList), StatusCodes.Status200OK)]
    public override Task GetProductListings(long collection_id, string? handle = null, int? limit = null,
        string? page_info = null, string? product_ids = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("product_listings/product_ids.json")]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    public override Task GetProductIds(int? limit = null, string? page_info = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("product_listings/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountProducts() => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("product_listings/{product_listing_id:long}.json")]
    [ProducesResponseType(typeof(ProductListingItem), StatusCodes.Status200OK)]
    public override Task GetProductListing([Required] long product_listing_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("product_listings/{product_listing_id:long}.json")]
    [ProducesResponseType(typeof(ProductListingItem), StatusCodes.Status200OK)]
    public override Task CreateProductListing([Required] CreateProductListingRequest request,
        [Required] long product_listing_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("product_listings/{product_listing_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteProductListing([Required] long product_listing_id) =>
        throw new NotImplementedException();
}