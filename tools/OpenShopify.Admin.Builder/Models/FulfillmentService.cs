

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify fulfillment service.
    /// </summary>
    public class FulfillmentServiceBase
    {
        /// <summary>
        /// The name of the fulfillment service as seen by merchants and their customers.
        /// </summary>
        [JsonPropertyName("name"), Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// States the URL endpoint that Shopify needs to retrieve inventory and tracking updates.
        /// This field is necessary if either inventory_management or tracking_support is set to "true".
        /// </summary>
        [JsonPropertyName("callback_url")]
        public string? CallbackUrl { get; set; }

        /// <summary>
        /// Specifies the format of the API output. Valid values are "json" and "xml".
        /// </summary>
        [JsonPropertyName("format"), Required]
        public FulfillmentServiceFormat Format { get; set; }

        /// <summary>
        /// A human-friendly unique string for the fulfillment service generated from its title.
        /// </summary>
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        /// <summary>
        /// States if the fulfillment service tracks product inventory and provides updates to Shopify.
        /// </summary>
        [JsonPropertyName("inventory_management")]
        public bool InventoryManagement { get; set; }

        /// <summary>
        /// The unique identifier of the location tied to the fulfillment service
        /// </summary>
        [JsonPropertyName("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// A unique identifier for the fulfillment service provider.
        /// </summary>
        [JsonPropertyName("provider_id")]
        public string? ProviderId { get; set; }

        /// <summary>
        /// States if the fulfillment service requires products to be physically shipped.
        /// </summary>
        [JsonPropertyName("requires_shipping_method")]
        public bool RequiresShippingMethod { get; set; }

        /// <summary>
        /// States if the fulfillment service provides tracking numbers for packages.
        /// </summary>
        [JsonPropertyName("tracking_support")]
        public bool TrackingSupport { get; set; }


        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("include_pending_stock")]
        public bool? IncludePendingStock { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("service_name")]
        public string? ServiceName { get; set; }

        /// <summary>
        /// Whether the fulfillment service wants to register for APIs related to fulfillment orders.
        /// </summary>
        [JsonPropertyName("fulfillment_orders_opt_in")]
        public bool? FulfillmentOrdersOptIn { get; set; }
    }
}