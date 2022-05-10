using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class CollectionListingController : CollectionListingControllerBase
{
    public override Task RetrieveCollectionListingsThatArePublishedToYourApp(string? limit = "50")
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveProductIdsThatArePublishedToCollectionId(string collection_listing_id, string? limit = "50")
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificCollectionListingThatIsPublishedToYourApp(string collection_listing_id)
    {
        throw new NotImplementedException();
    }

    public override Task CreateCollectionListingToPublishCollectionToYourApp(string collection_listing_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteCollectionListingToUnpublishCollectionFromYourApp(string collection_listing_id)
    {
        throw new NotImplementedException();
    }
}