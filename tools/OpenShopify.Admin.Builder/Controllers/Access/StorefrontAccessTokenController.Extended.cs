﻿using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Access;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Access)]
[ApiController]
public class StorefrontAccessTokenController : StorefrontAccessTokenControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("storefront_access_tokens.json")]
    [ProducesResponseType(typeof(StorefrontAccessTokenItem), StatusCodes.Status200OK)]
    public override Task CreateNewStorefrontAccessToken(CreateStorefrontAccessTokenRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("storefront_access_tokens.json")]
    [ProducesResponseType(typeof(StorefrontAccessTokenList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfStorefrontAccessTokensThatHaveBeenIssued()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("storefront_access_tokens/{storefront_access_token_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteExistingStorefrontAccessToken(long storefront_access_token_id)
    {
        throw new NotImplementedException();
    }
}