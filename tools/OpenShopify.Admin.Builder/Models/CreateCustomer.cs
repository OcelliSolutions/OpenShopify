using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CreateCustomer
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

    /// <summary>
    /// Whether an email invite should be sent to the new customer. Default is null.
    /// </summary>
    [JsonPropertyName("send_email_invite")]
    public bool? SendEmailInvite { get; set; }

    /// <summary>
    /// Whether a welcome email should be sent to the new customer. Default is null.
    /// </summary>
    [JsonPropertyName("send_email_welcome")]
    public bool? SendWelcomeEmail { get; set; }

    /// <summary>
    /// A list of addresses for the customer.
    /// </summary>
    [JsonPropertyName("addresses")]
    public new IEnumerable<CreateCustomerAddress>? Addresses { get; set; }

    /// <summary>
    /// The default address for the customer.
    /// </summary>
    [JsonPropertyName("default_address")]
    public new CreateCustomerAddress? DefaultAddress { get; set; }
}
