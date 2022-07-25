using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Plus;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Plus)]
[ApiController]
public class GiftCardController : GiftCardControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("gift_cards.json")]
    [ProducesResponseType(typeof(GiftCardList), StatusCodes.Status200OK)]
    public override Task ListGiftCards(string? fields = null, int? limit = null, string? page_info = null,
        long? since_id = null, string? status = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("gift_cards.json")]
    [ProducesResponseType(typeof(GiftCardItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(GiftCardError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateGiftCard([Required] CreateGiftCardRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("gift_cards/{gift_card_id:long}.json")]
    [ProducesResponseType(typeof(GiftCardItem), StatusCodes.Status200OK)]
    public override Task GetGiftCard([Required] long gift_card_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("gift_cards/{gift_card_id:long}.json")]
    [ProducesResponseType(typeof(GiftCardItem), StatusCodes.Status200OK)]
    public override Task UpdateGiftCard([Required] UpdateGiftCardRequest request, [Required] long gift_card_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("gift_cards/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountGiftCards(string? status = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("gift_cards/{gift_card_id:long}/disable.json")]
    [ProducesResponseType(typeof(GiftCardItem), StatusCodes.Status200OK)]
    public override Task DisableGiftCard([Required] long gift_card_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("gift_cards/search.json")]
    [ProducesResponseType(typeof(GiftCardList), StatusCodes.Status200OK)]
    public override Task SearchForGiftCards(string? fields = null, int? limit = null, string? page_info = null,
        string? order = null, string? query = null) => throw new NotImplementedException();
}