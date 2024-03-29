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

    public abstract class CustomerSavedSearchControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of customer saved searches
        /// </summary>
        /// <remarks>
        /// Retrieves a list of customer saved searches. This endpoint implements pagination by using links that are provided in the response header. Sending the `page` parameter will return an error. To learn more, see [*Make paginated requests to the REST Admin API*](/api/usage/pagination-rest).
        /// </remarks>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <param name="limit">The maximum number of results to show.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches.json")]
        public abstract System.Threading.Tasks.Task ListCustomerSavedSearches([Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null);

        /// <summary>
        /// Creates a customer saved search
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches.json")]
        public abstract System.Threading.Tasks.Task CreateCustomerSavedSearch([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateCustomerSavedSearchRequest request);

        /// <summary>
        /// Retrieves a count of all customer saved searches
        /// </summary>
        /// <param name="since_id">Restrict results to after the specified ID</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/count.json")]
        public abstract System.Threading.Tasks.Task CountCustomerSavedSearches([Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null);

        /// <summary>
        /// Retrieves a single customer saved search
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/{customer_saved_search_id}.json")]
        public abstract System.Threading.Tasks.Task GetCustomerSavedSearch(long customer_saved_search_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Updates a customer saved search
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/{customer_saved_search_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateCustomerSavedSearch([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateCustomerSavedSearchRequest request, long customer_saved_search_id);

        /// <summary>
        /// Deletes a customer saved search
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/{customer_saved_search_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteCustomerSavedSearch(long customer_saved_search_id);

        /// <summary>
        /// Retrieves all customers returned by a customer saved search
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <param name="limit">The maximum number of results to show.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="order">Set the field and direction by which to order results.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/{customer_saved_search_id}/customers.json")]
        public abstract System.Threading.Tasks.Task ListCustomersByCustomerSavedSearch(long customer_saved_search_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? order = null);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record CustomerSavedSearchOrig
    {
        /// <summary>
        /// The name given by the shop owner to the customer saved search.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Name { get; set; } = default!;

        /// <summary>
        /// The set of conditions that determines which customers are returned by the saved search. For more information, see [*Customer saved search queries*](#customer-saved-search-queries).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("query")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Query { get; set; } = default!;

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