using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class InventoryLevelBase
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
        /// The quantity of inventory items available for sale. Returns null if the inventory item is not tracked.
        /// </summary>
        [JsonPropertyName("available")]
        public long? Available { get; set; }

        /// <summary>
        /// The date and time when the inventory level was last modified.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
