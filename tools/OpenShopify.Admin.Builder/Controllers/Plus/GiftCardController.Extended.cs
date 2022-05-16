using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Plus;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Plus)]
[ApiController]
public class GiftCardController : IGiftCardController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("gift_cards.json")]
    public Task RetrieveListOfGiftCardsAsync(string? fields, string limit, string? since_id, string? status)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("gift_cards.json")]
    public Task CreateGiftCardAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("gift_cards/{gift_card_id}.json")]
    public Task RetrieveSingleGiftCardAsync(string gift_card_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("gift_cards/{gift_card_id}.json")]

    public Task UpdateExistingGiftCardAsync(string gift_card_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("gift_cards/count.json")]
    public Task RetrieveCountOfGiftCardsAsync(string? status)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("gift_cards/{gift_card_id}/disable.json")]
    public Task DisableGiftCardAsync(string gift_card_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("gift_cards/search.json")]
    public Task SearchForGiftCardsAsync(string? fields, string limit, string order, string? query)
    {
        throw new NotImplementedException();
    }
}