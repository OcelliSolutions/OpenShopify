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
    public override Task RetrieveCollectionListingsThatArePublishedToYourApp(int? limit, string? page_info)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("collection_listings/{collection_listing_id:long}/product_ids.json")]
    public override Task RetrieveProductIdsThatArePublishedToCollectionId(long collection_listing_id, int? limit, string? page_info)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("collection_listings/{collection_listing_id:long}.json")]
    public override Task RetrieveSpecificCollectionListingThatIsPublishedToYourApp(long collection_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("collection_listings/{collection_listing_id:long}.json")]
    public override Task CreateCollectionListingToPublishCollectionToYourApp(CreateCollectionListingRequest request,
        long collection_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("collection_listings/{collection_listing_id:long}.json")]
    public override Task DeleteCollectionListingToUnpublishCollectionFromYourApp(long collection_listing_id)
    {
        throw new NotImplementedException();
    }
}