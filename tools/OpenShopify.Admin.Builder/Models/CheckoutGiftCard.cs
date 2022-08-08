using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CheckoutGiftCard
{
    /// <summary>
    /// The ID for the applied gift card
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>
    /// The amount of the gift card used by this checkout in presentment currency.
    /// </summary>
    [JsonPropertyName("amount_used")]
    public decimal? AmountUsed { get; set; } = default!;

    /// <summary>
    /// The gift card code
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; } = default!;

    /// <summary>
    /// The amount left on the gift card after being applied to this checkout in presentment currency.
    /// </summary>
    [JsonPropertyName("balance")]
    public decimal? Balance { get; set; } = default!;

    /// <summary>
    /// The last four characters of the applied gift card for display back to the user.
    /// Updating the gift card list overwrites any previous list already defined in the checkout.To remove a gift card from the list of applied gift cards, re-apply the `gift_cards` array without that gift card.
    /// </summary>

    [JsonPropertyName("last_characters")]
    public string? LastCharacters { get; set; } = default!;
}
