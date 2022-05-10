

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class FulfillmentOrderLineItem
    {
        /// <summary>
        /// The ID of the fulfillment order line item.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The ID of the shop associated with the fulfillment order line item.
        /// </summary>
        [JsonPropertyName("shop_id")]
        public long? ShopId { get; set; }

        /// <summary>
        /// The ID of the fulfillment order associated with this line item.
        /// </summary>
        [JsonPropertyName("fulfillment_order_id")]
        public long? FulfillmentOrderId { get; set; }

        /// <summary>
        /// The ID of the line item associated with this fulfillment order line item.
        /// </summary>
        [JsonPropertyName("line_item_id")]
        public long? LineItemId { get; set; }

        /// <summary>
        /// The ID of the inventory item associated with this fulfillment order line item.
        /// </summary>
        [JsonPropertyName("inventory_item_id")]
        public long? InventoryItemId { get; set; }

        /// <summary>
        /// The total number of units to be fulfilled.
        /// </summary>
        [JsonPropertyName("quantity")]
        public long? Quantity { get; set; }

        /// <summary>
        /// The number of units remaining to be fulfilled.
        /// </summary>
        [JsonPropertyName("fulfillable_quantity")]
        public long? FulfillableQuantity { get; set; }

        /// <summary>
        /// The ID of the variant associated with this fulfillment order line item.
        /// </summary>
        [JsonPropertyName("variant_id")]
        public long? VariantId { get; set; }
    }
}
