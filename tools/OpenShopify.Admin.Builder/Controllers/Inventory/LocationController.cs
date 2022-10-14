//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
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

namespace OpenShopify.Admin.Builder.Models
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class LocationControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieve a list of locations
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("locations.json")]
        public abstract System.Threading.Tasks.Task ListLocations();

        /// <summary>
        /// Retrieve a single location by its ID
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("locations/{location_id}.json")]
        public abstract System.Threading.Tasks.Task GetLocation(long location_id);

        /// <summary>
        /// Retrieve a count of locations
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("locations/count.json")]
        public abstract System.Threading.Tasks.Task CountLocations();

        /// <summary>
        /// Retrieve a list of inventory levels for a location
        /// </summary>
        /// <remarks>
        /// Retrieve a list of inventory levels for a location. **Note:** This endpoint implements pagination by using links that are provided in the response header. To learn more, refer to [Make paginated requests to the REST Admin API](/api/usage/pagination-rest).
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("locations/{location_id}/inventory_levels.json")]
        public abstract System.Threading.Tasks.Task ListInventoryLevelsForLocation(long location_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record LocationOrig
    {
        /// <summary>
        /// Whether the location is active. If `true`, then the location can be used to sell products,stock inventory, and fulfill orders. Merchants can deactivate locations from the Shopify admin.Deactivated locations don't contribute to the shop's[location limit](https://help.shopify.com/manual/locations/setting-up-your-locations).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("active")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public bool? Active { get; set; } = default!;

        /// <summary>
        /// The location's street address.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("address1")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Address1 { get; set; } = default!;

        /// <summary>
        /// The optional second line of the location's street address.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("address2")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Address2 { get; set; } = default!;

        /// <summary>
        /// The city the location is in.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("city")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? City { get; set; } = default!;

        /// <summary>
        /// The country the location is in.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("country")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Country { get; set; } = default!;

        /// <summary>
        /// The two-letter code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) format) corresponding to country the location is in.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("country_code")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? CountryCode { get; set; } = default!;

        /// <summary>
        /// Whether this is a fulfillment service location. If `true`, then the location is a fulfillment service location. If `false`, then the location was created by the merchant and isn't tied to a fulfillment service.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("legacy")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public bool? Legacy { get; set; } = default!;

        /// <summary>
        /// The name of the location.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Name { get; set; } = default!;

        /// <summary>
        /// The phone number of the location. This value can contain special characters, such as `-` or `+`.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("phone")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Phone { get; set; } = default!;

        /// <summary>
        /// The province, state, or district of the location.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("province")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Province { get; set; } = default!;

        /// <summary>
        /// The province, state, or district code ([ISO 3166-2 alpha-2 format](https://en.wikipedia.org/wiki/ISO_3166-2)) of the location.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("province_code")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? ProvinceCode { get; set; } = default!;

        /// <summary>
        /// The zip or postal code.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("zip")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Zip { get; set; } = default!;

        /// <summary>
        /// The localized name of the location's country.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("localized_country_name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? LocalizedCountryName { get; set; } = default!;

        /// <summary>
        /// The localized name of the location's region. Typically a province, state, or district.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("localized_province_name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? LocalizedProvinceName { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
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