

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class CheckoutShippingRate
    {
        public CheckoutShippingRate()
        {

        }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        [JsonPropertyName("price")]
        public string? Price { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("phoneRequired")]
        public bool PhoneRequired { get; set; }

        /// <summary>
        /// As of 2019-01-21, the type of this property is unknown. In Shopify's documentation, it only appears as a null value.
        /// </summary>
        [JsonPropertyName("deliveryRange")]
        public object DeliveryRange { get; set; }

        [JsonPropertyName("checkout")]
        public CheckoutShippingRatePrices Checkout { get; set; }
    }
}