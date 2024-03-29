using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record ExtendedAuthorizationAttributes
{
    /// <summary>
    /// The date and time (ISO 8601 format) when the standard authorization period expires. After expiry, an extended authorization fee is applied upon capturing the payment.
    /// </summary>
    [JsonPropertyName("standard_authorization_expires_at")]
    public DateTimeOffset? StandardAuthorizationExpiresAt { get; set; }

    /// <summary>
    /// The date and time (ISO 8601 format) when the extended authorization period expires. After expiry, the merchant can't capture the payment.
    /// </summary>
    [JsonPropertyName("extended_authorization_expires_at")]
    public DateTimeOffset? ExtendedAuthorizationExpiresAt { get; set; }
}