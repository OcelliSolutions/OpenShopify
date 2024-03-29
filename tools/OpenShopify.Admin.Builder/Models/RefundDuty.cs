﻿using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record RefundDuty
    {
        [JsonPropertyName("duty_id")]
        public long? DutyId { get; set; }

        [JsonPropertyName("amount_set")]
        public PriceSet? AmountSet { get; set; }
    }
}
