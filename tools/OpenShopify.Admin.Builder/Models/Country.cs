using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class Country : ShopifyObject
    {
        /// <summary>
        /// The full name of the country, in English.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The tax value in decimal format.
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("tax")]
        public decimal? Tax { get; set; }

        /// <summary>
        /// The ISO 3166-1 alpha-2 two-letter country code for the country. The code for a given country will be the same as the code for the same country in another shop.
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        /// <summary>
        /// The name of the tax as it is referred to in the applicable province/state. For example, in Ontario, Canada the tax is referred to as HST.
        /// </summary>
        [JsonPropertyName("tax_name")]
        public string? TaxName { get; set; }

        /// <summary>
        /// The sub-regions of a country. The term provinces also encompasses states.
        /// </summary>
        [JsonPropertyName("provinces")]
        public IEnumerable<Province> Provinces { get; set; }
    }
}