using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// This is used to view shipping zones, their countries, provinces, and shipping rates.
    /// </summary>
    public class ShippingZoneBase
    {
        /// <summary>
        /// The name of the shipping zone, specified by the user.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// A list of countries that belong to the shipping zone.
        /// </summary>
        [JsonPropertyName("countries")]
        public IEnumerable<Country> Countries { get; set; }

        /// <summary>
        /// Information about weight based shipping rates used.
        /// </summary>
        [JsonPropertyName("weight_based_shipping_rates")]
        public IEnumerable<WeightBasedShippingRate> WeightBasedShippingRates { get; set; }

        /// <summary>
        /// Information about price based shipping rates used.
        /// </summary>
        [JsonPropertyName("price_based_shipping_rates")]
        public IEnumerable<PriceBasedShippingRate> PriceBasedShippingRates { get; set; }

        /// <summary>
        /// Information about carrier shipping providers and the rates used.
        /// </summary>
        [JsonPropertyName("carrier_shipping_rate_providers")]
        public IEnumerable<CarrierShippingRateProvider> CarrierShippingRateProviders { get; set; }
    }
}