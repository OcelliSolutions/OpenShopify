//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#nullable enable

using System.Text.Json;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"

namespace OpenShopify.Admin.Builder
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class ShippingZoneControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Receive a list of all ShippingZones
        /// </summary>
        /// <param name="fields">comma-separated list of fields to include in the response</param>
        /// <returns>Receive a list of all ShippingZones</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/shipping_zones.json")]
        public abstract System.Threading.Tasks.Task ReceiveListOfAllShippingzones([Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ShippingZone
    {
        /// <summary>
        /// The unique numeric identifier for the shipping zone.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; } = default!;

        /// <summary>
        /// The name of the shipping zone, specified by the user.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; } = default!;

        /// <summary>
        /// The ID of the shipping zone's delivery profile. Shipping profiles allow merchants  to create product-based or location-based shipping rates.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("profile_id")]
        public string? Profile_id { get; set; } = default!;

        /// <summary>
        /// The ID of the shipping zone's location group. Location groups allow merchants  to create shipping rates that apply only to the specific locations in the group.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("location_group_id")]
        public string? Location_group_id { get; set; } = default!;

        /// <summary>
        /// A list of countries that belong to the shipping zone.
        /// <br/> 
        /// <br/> id: The unique numeric identifier for the country.
        /// <br/> code: The ISO 3166-1 alpha-2 two-letter country code for the country. The code for a given country will be the same as the code for the same country in another shop.
        /// <br/> shipping_zone_id: The unique numeric identifier for the shipping zone.
        /// <br/> name: The full name of the country, in English.
        /// <br/> tax: The tax value in decimal format.
        /// <br/> tax_name: The name of the tax as it is referred to in the applicable province/state. For example, in Ontario, Canada the tax is referred to as HST.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("countries")]
        public string? Countries { get; set; } = default!;

        /// <summary>
        /// The sub-regions of a country. The term provinces also encompasses states.
        /// <br/> 
        /// <br/> code: The two letter province or state code.
        /// <br/> country_id: The unique numeric identifier for the country.
        /// <br/> shipping_zone_id: The unique numeric identifier for the shipping zone.
        /// <br/> id: The unique numeric identifier for the particular province or state.
        /// <br/> name: The name of the province or state.
        /// <br/> tax: The tax value in decimal format.
        /// <br/> tax_name: The name of the tax as it is referred to in the applicable province/state. For example, in Ontario, Canada the tax is referred to as HST.
        /// <br/> tax_type: A tax_type is applied for a compounded sales tax. For example, the Canadian HST is a compounded sales tax of both PST and GST.
        /// <br/> tax_percentage: The tax value in percent format.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("provinces")]
        public string? Provinces { get; set; } = default!;

        /// <summary>
        /// Information about carrier shipping providers and the rates used.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("carrier_shipping_rate_providers")]
        public string? Carrier_shipping_rate_providers { get; set; } = default!;

        /// <summary>
        /// Information about a price-based shipping rate.
        /// <br/> 
        /// <br/> id: The unique numeric identifier for the shipping rate.
        /// <br/> name: The name of the shipping rate.
        /// <br/> price: The price of the shipping rate.
        /// <br/> shipping_zone_id: The unique numeric identifier for the associated shipping zone.
        /// <br/> min_order_subtotal: The minimum price of an order for it to be eligible for the shipping rate.
        /// <br/> max_order_subtotal: The maximum price of an order for it to be eligible for the shipping rate.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("price_based_shipping_rates")]
        public string? Price_based_shipping_rates { get; set; } = default!;

        /// <summary>
        /// Information about a weight-based shipping rate.
        /// <br/> 
        /// <br/> id: The unique numeric identifier for the shipping rate.
        /// <br/> name: The name of the shipping rate.
        /// <br/> price: The price of the shipping rate.
        /// <br/> shipping_zone_id: The unique numeric identifier for the associated shipping zone.
        /// <br/> weight_low: The minimum weight of an order for it to be eligible for the shipping rate.
        /// <br/> weight_high: The maximum weight of an order for it to be eligible for the shipping rate.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("weight_based_shipping_rates")]
        public string? Weight_based_shipping_rates { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

    }


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603