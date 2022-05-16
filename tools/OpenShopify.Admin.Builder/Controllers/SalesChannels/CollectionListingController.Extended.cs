using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class CollectionListingController : ICollectionListingController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("collection_listings.json")]
    public Task RetrieveCollectionListingsThatArePublishedToYourAppAsync(string limit)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}/product_ids.json")]
    public Task RetrieveProductIdsThatArePublishedToCollectionIdAsync(string collection_listing_id, string limit)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}.json")]
    public Task RetrieveSpecificCollectionListingThatIsPublishedToYourAppAsync(string collection_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}.json")]
    public Task CreateCollectionListingToPublishCollectionToYourAppAsync(string collection_listing_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}.json")]
    public Task DeleteCollectionListingToUnpublishCollectionFromYourAppAsync(string collection_listing_id)
    {
        throw new NotImplementedException();
    }
}