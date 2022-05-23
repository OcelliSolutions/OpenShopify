using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify fulfillment.
    /// </summary>
    public partial record FulfillmentBase
    {
        /// <inheritdoc cref="FulfillmentOrig.LineItems"/>
        [JsonPropertyName("line_items")]
        public new IEnumerable<LineItem>? LineItems { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify. It appears to be the shipping address of the order
        /// </summary>
        [JsonPropertyName("destination")]
        public Address? Destination { get; set; }
    }
}
