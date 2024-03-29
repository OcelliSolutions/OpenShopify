﻿

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record MerchantRequest
    {
        /// <summary>
        /// The message returned by the merchant, if any.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// The request options returned by the merchant, if any.
        /// </summary>
        [JsonPropertyName("request_options")]
        public MerchantRequestOptions? RequestOptions { get; set; }

        /// <summary>
        /// The kind of request. Known valid values: "fulfillment_request", "cancellation_request", or "legacy_fulfill_request".
        /// </summary>
        [JsonPropertyName("kind")]
        public string? Kind { get; set; }
    }
}