

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record HsCode : ShopifyObject
    {
        /// <summary>
        /// The two-digit code for the country where the inventory item was made.
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// The general Harmonized System (HS) code for the inventory item. Used if a country-specific HS code is not available.
        /// </summary>
        [JsonPropertyName("harmonized_system_code")]
        public string? HarmonizedSystemCode { get; set; }
    }
}
