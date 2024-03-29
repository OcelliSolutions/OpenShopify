﻿using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record CarrierServiceBase
{
    [JsonPropertyName("format")]
    public CarrierServiceFormat? Format { get; set; }
}
