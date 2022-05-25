

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record AssignedLocation
    {
        /// <summary>
        ///  The street address of the assigned location.
        /// </summary>
        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }

        /// <summary>
        /// An optional additional field for the street address of the assigned location.
        /// </summary>
        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }

        /// <summary>
        /// The city of the assigned location.
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// The two-letter code for the country of the assigned location.
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// The ID of the assigned location.
        /// </summary>
        [JsonPropertyName("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// The name of the assigned location.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The phone number of the assigned location.
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// The province of the assigned location.
        /// </summary>
        [JsonPropertyName("province")]
        public string? Province { get; set; }

        /// <summary>
        ///  The ZIP code of the assigned location.
        /// </summary>
        [JsonPropertyName("zip")]
        public string? Zip { get; set; }
    }
}