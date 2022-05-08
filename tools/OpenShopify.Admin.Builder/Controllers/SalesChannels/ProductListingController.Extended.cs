using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class ProductListingController : ProductListingControllerBase
{
    public override Task RetrieveProductListingsThatArePublishedToYourApp(string? collection_id = null, string? handle = null,
        string? limit = "50", string? product_ids = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCodeProductIdsCodeThatArePublishedToYourApp(string? limit = "50")
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfProductsThatArePublishedToYourApp()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificProductListingThatIsPublishedToYourApp(string product_listing_id)
    {
        throw new NotImplementedException();
    }

    public override Task CreateProductListingToPublishProductToYourApp(string product_listing_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteProductListingToUnpublishProductFromYourApp(string product_listing_id)
    {
        throw new NotImplementedException();
    }
}