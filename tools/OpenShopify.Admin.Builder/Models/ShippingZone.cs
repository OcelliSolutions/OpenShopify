using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// This is used to view shipping zones, their countries, provinces, and shipping rates.
    /// </summary>
    public partial record ShippingZone
    {
        /// <inheritdoc cref="ShippingZoneOrig.Countries"/>
        [JsonPropertyName("countries")]
        public new IEnumerable<Country>? Countries { get; set; }

        /// <inheritdoc cref="ShippingZoneOrig.WeightBasedShippingRates"/>
        [JsonPropertyName("weight_based_shipping_rates")]
        public new IEnumerable<WeightBasedShippingRate>? WeightBasedShippingRates { get; set; }

        /// <inheritdoc cref="ShippingZoneOrig.PriceBasedShippingRates"/>
        [JsonPropertyName("price_based_shipping_rates")]
        public new IEnumerable<PriceBasedShippingRate>? PriceBasedShippingRates { get; set; }

        /// <inheritdoc cref="ShippingZoneOrig.CarrierShippingRateProviders"/>
        [JsonPropertyName("carrier_shipping_rate_providers")]
        public new IEnumerable<CarrierShippingRateProvider>? CarrierShippingRateProviders { get; set; }
    }
}