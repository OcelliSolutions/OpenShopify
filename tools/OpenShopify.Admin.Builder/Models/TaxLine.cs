using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class TaxLine
    {
        /// <summary>
        /// The amount of tax to be charged.
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// The rate of tax to be applied.
        /// </summary>
        [JsonPropertyName("rate")]
        public decimal? Rate { get; set; }

        /// <summary>
        /// The name of the tax.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// The amount added to the order for this tax in shop and presentment currencies.
        /// </summary>
        [JsonPropertyName("price_set")]
        public PriceSet PriceSet { get; set; }
    }
}
