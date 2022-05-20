using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Plus;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Plus)]
[ApiController]
public class GiftCardController : GiftCardControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("gift_cards.json")]
    public override Task ListGiftCards(string? fields, int? limit, string? page_info, int? since_id, string? status)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("gift_cards.json")]
    public override Task CreateGiftCard([Required] CreateGiftCardRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("gift_cards/{gift_card_id:long}.json")]
    public override Task GetGiftCard([Required] long gift_card_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("gift_cards/{gift_card_id:long}.json")]
    public override Task UpdateGiftCard([Required] UpdateGiftCardRequest request, [Required] long gift_card_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("gift_cards/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountGiftCards(string? status)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("gift_cards/{gift_card_id:long}/disable.json")]
    public override Task DisableGiftCard([Required] long gift_card_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("gift_cards/search.json")]
    public override Task SearchForGiftCards(string? fields, int? limit, string? page_info, string order, string? query)
    {
        throw new NotImplementedException();
    }
}
