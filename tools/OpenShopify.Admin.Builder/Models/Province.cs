using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class ProvinceBase
    {
        /// <summary>
        /// The unique numeric identifier for the country.
        /// </summary>
        [JsonPropertyName("country_id")]
        public long? CountryId { get; set; }

        /// <summary>
        /// The name of the province or state.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The two letter province or state code.
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        /// <summary>
        ///  The tax value in decimal format.
        /// </summary>
        [JsonPropertyName("tax")]
        public decimal? Tax { get; set; }

        /// <summary>
        /// The name of the tax as it is referred to in the applicable province/state. For example, in Ontario, Canada the tax is referred to as HST.
        /// </summary>
        [JsonPropertyName("tax_name")]
        public string? TaxName { get; set; }

        /// <summary>
        /// A tax_type is applied for a compounded sales tax. For example, the Canadian HST is a compounded sales tax of both PST and GST.
        /// </summary>
        [JsonPropertyName("tax_type")]
        public string? TaxType { get; set; }

        /// <summary>
        /// The unique numeric identifier for the shipping zone.
        /// </summary>
        [JsonPropertyName("shipping_zone_id")]
        public long? ShippingZoneId { get; set; }

        /// <summary>
        ///  The tax value in percent format.
        /// </summary>
        [JsonPropertyName("tax_percentage")]
        public decimal? TaxPercentage { get; set; }
    }
}