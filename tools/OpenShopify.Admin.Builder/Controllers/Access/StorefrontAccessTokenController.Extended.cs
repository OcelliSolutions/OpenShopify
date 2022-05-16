using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Access;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Access)]
[ApiController]
public class StorefrontAccessTokenController : IStorefrontAccessTokenController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("storefront_access_tokens.json")]
    [ProducesResponseType(typeof(StorefrontAccessTokenItem), StatusCodes.Status200OK)]
    public Task CreateNewStorefrontAccessTokenAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("storefront_access_tokens.json")]
    [ProducesResponseType(typeof(StorefrontAccessTokenList), StatusCodes.Status200OK)]
    public Task RetrieveListOfStorefrontAccessTokensThatHaveBeenIssuedAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("storefront_access_tokens/{storefront_access_token_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task DeleteExistingStorefrontAccessTokenAsync(string storefront_access_token_id)
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
