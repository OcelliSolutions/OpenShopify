using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Access;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Access)]
[ApiController]
public class StorefrontAccessTokenController : StorefrontAccessTokenControllerBase
{
    /// <inheritdoc />
    [ProducesResponseType(typeof(StorefrontAccessTokenItem), StatusCodes.Status200OK)]
    public override Task CreateNewStorefrontAccessToken()
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
    public override Task DeleteExistingStorefrontAccessToken([FromRoute] string storefront_access_token_id)
    {
        throw new NotImplementedException();
    }
}

public class StorefrontAccessTokenItem
{
    [JsonPropertyName("storefront_access_token")]
    public StorefrontAccessToken? StorefrontAccessToken { get; set; }
}

public class StorefrontAccessTokenList
{
    [JsonPropertyName("storefront_access_tokens")]
    public IEnumerable<StorefrontAccessToken>? StorefrontAccessTokens { get; set; }
}
