using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Access;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Access)]
[ApiController]
public class StorefrontAccessTokenController : StorefrontAccessTokenControllerBase
{
    /// <inheritdoc />
    [ProducesResponseType(typeof(StorefrontAccessToken), StatusCodes.Status200OK)]
    public override Task CreateNewStorefrontaccesstoken()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(StorefrontAccessTokenList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfStorefrontAccessTokensThatHaveBeenIssued()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteExistingStorefrontAccessToken(string storefront_access_token_id)
    {
        throw new NotImplementedException();
    }
}
