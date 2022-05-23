using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record InventoryItemBase
    {
        /// <inheritdoc cref="InventoryItemOrig.CountryHarmonizedSystemCodes"/>
        [JsonPropertyName("country_harmonized_system_codes")]
        public new IEnumerable<HsCode>? CountryHarmonizedSystemCodes { get; set; }
    }
}
