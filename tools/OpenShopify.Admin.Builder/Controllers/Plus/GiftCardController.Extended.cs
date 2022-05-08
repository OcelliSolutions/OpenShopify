using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Plus;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Plus)]
[ApiController]
public class GiftCardController : GiftCardControllerBase
{
    public override Task RetrieveListOfGiftCards(string? fields = null, string? limit = "50", string? since_id = null,
        string? status = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateGiftCard()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleGiftCard(string gift_card_id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingGiftCard(string gift_card_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfGiftCards(string? status = null)
    {
        throw new NotImplementedException();
    }

    public override Task DisableGiftCard(string gift_card_id)
    {
        throw new NotImplementedException();
    }

    public override Task SearchForGiftCards(string? fields = null, string? limit = "50", string? order = "disabled_at DESC",
        string? query = null)
    {
        throw new NotImplementedException();
    }
}