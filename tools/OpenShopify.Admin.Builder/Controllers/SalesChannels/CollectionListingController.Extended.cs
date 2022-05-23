using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class CollectionListingController : CollectionListingControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("collection_listings.json")]
    [ProducesResponseType(typeof(CollectionListingList), StatusCodes.Status200OK)]
    public override Task GetCollectionListingsThatArePublishedToYourApp(int? limit = null, string? page_info = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("collection_listings/{collection_listing_id:long}/product_ids.json")]
    [ProducesResponseType(typeof(ProductList), StatusCodes.Status200OK)]
    public override Task GetProductIdsThatArePublishedToCollectionId([Required] long collection_listing_id, int? limit = null, string? page_info = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("collection_listings/{collection_listing_id:long}.json")]
    [ProducesResponseType(typeof(CollectionListingItem), StatusCodes.Status200OK)]
    public override Task GetSpecificCollectionListingThatIsPublishedToYourApp([Required] long collection_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("collection_listings/{collection_listing_id:long}.json")]
    [ProducesResponseType(typeof(CollectionListingItem), StatusCodes.Status201Created)]
    public override Task CreateCollectionListingToPublishCollectionToYourApp([Required] CreateCollectionListingRequest request,
        [Required] long collection_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("collection_listings/{collection_listing_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteCollectionListingToUnpublishCollectionFromYourApp([Required] long collection_listing_id)
    {
        throw new NotImplementedException();
    }
}