

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record FulfillmentOrderDestination
    {
        /// <summary>
        /// The ID of the fulfillment order destination.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The street address of the assigned location.
        /// </summary>
        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }

        /// <summary>
        /// An optional additional field for the street address of the assigned location.
        /// </summary>
        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }

        /// <summary>
        /// The city of the destination.
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// The company of the destination.
        /// </summary>
        [JsonPropertyName("company")]
        public string? Company { get; set; }

        /// <summary>
        /// The country of the destination.
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// The email of the customer at the destination.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// The first name of the customer at the destination.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// The last name of the customer at the destination.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// The phone number of the customer at the destination.
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// The province of the destination.
        /// </summary>
        [JsonPropertyName("province")]
        public string? Province { get; set; }

        /// <summary>
        /// The ZIP code of the destination.
        /// </summary>
        [JsonPropertyName("zip")]
        public string? Zip { get; set; }
    }
}
