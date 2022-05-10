using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class InventoryLevelAdjust
    {
        /// <summary>
        /// The unique identifier of the inventory item that the inventory level belongs to.
        /// </summary>
        [JsonPropertyName("inventory_item_id")]
        public long? InventoryItemId { get; set; }

        /// <summary>
        /// The unique identifier of the location that the inventory level belongs to.
        /// </summary>
        [JsonPropertyName("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// The quantity adjust of inventory items.
        /// </summary>
        [JsonPropertyName("available_adjustment")]
        public int? AvailableAdjustment { get; set; }
    }
}