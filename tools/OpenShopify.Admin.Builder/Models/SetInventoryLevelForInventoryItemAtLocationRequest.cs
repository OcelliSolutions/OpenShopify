using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public class SetInventoryLevelForInventoryItemAtLocationRequest
{
    /// <summary>
    /// The ID of the inventory item.
    /// </summary>
    [JsonPropertyName("inventory_item_id"), Required]
    public long InventoryItemId { get; set; }

    /// <summary>
    /// The ID of the location that the inventory level belongs to. To find the ID of the location, use the Location resource.
    /// </summary>
    [JsonPropertyName("location_id"), Required]
    public long LocationId { get; set; }

    /// <summary>
    /// Sets the available inventory quantity.
    /// </summary>
    [JsonPropertyName("available"), Required]
    public decimal Available { get; set; }

    /// <summary>
    /// Whether inventory for any previously connected locations will be set to 0 and the locations disconnected. This property is ignored when no fulfillment service is involved. For more information, refer to Inventory levels and fulfillment service locations.
    /// </summary>
    [JsonPropertyName("disconnect_if_necessary")]
    public bool? DisconnectIfNecessary { get; set; }
}
