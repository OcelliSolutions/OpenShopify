using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CreateCustomer
{
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
