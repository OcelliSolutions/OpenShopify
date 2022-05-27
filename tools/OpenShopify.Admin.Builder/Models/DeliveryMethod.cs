using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models
{
    public record DeliveryMethod
    {
        /// <summary>
        /// The ID of the delivery method.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The type of delivery method. Valid values.
        /// <br>local: A delivery to a customer's doorstep</br>
        /// <br>none: No delivery method</br>
        /// <br>pick_up: A delivery that a customer picks up at your retail store, curbside, or any location that you choose</br>
        /// <br>retail: A delivery to a retail store</br>
        /// <br>shipping: A delivery to a customer using a shipping carrier</br>
        /// </summary>
        [JsonPropertyName("method_type")]
        public DeliveryMethodType? MethodType { get; set; }

        /// <summary>
        /// The minimum date and time by which the delivery is expected to be completed.
        /// </summary>
        [JsonPropertyName("min_delivery_date_time")]
        public DateTimeOffset? MinDeliveryDateTime { get; set; }

        /// <summary>
        /// The maximum date and time by which the delivery is expected to be completed.
        /// </summary>
        [JsonPropertyName("max_delivery_date_time")]
        public DateTimeOffset? MaxDeliveryDateTime { get; set; }
    }
}
