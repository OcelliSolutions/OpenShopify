using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record UpdateCustomer
{
    /// <summary>
    /// An optional password for the user. Default is null.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Should be set and match <see cref="Password"/>. Default is null.
    /// </summary>
    [JsonPropertyName("password_confirmation")]
    public string? PasswordConfirmation { get; set; }
}
