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

    public abstract class ReportControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of reports
        /// </summary>
        /// <remarks>
        /// Retrieves a list of reports. **Note:** As of version 2019-10, this endpoint implements pagination by using links that are provided in the response header. Sending the `page` parameter will return an error. To learn more, see [*Make paginated requests to the REST Admin API*](/api/usage/pagination-rest).
        /// </remarks>
        /// <param name="fields">A comma-separated list of fields to include in the response.</param>
        /// <param name="ids">A comma-separated list of report IDs.</param>
        /// <param name="limit">The amount of results to return.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        /// <param name="updated_at_max">Show reports last updated before date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="updated_at_min">Show reports last updated after date. (format: 2014-04-25T16:15:47-04:00)</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("reports.json")]
        public abstract System.Threading.Tasks.Task ListReports([Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.Collections.Generic.IEnumerable<long>? ids = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_min = null);

        /// <summary>
        /// Creates a new report
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("reports.json")]
        public abstract System.Threading.Tasks.Task CreateReport([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateReportRequest request);

        /// <summary>
        /// Retrieves a single report
        /// </summary>
        /// <remarks>
        /// Retrieves a single report created by your app
        /// </remarks>
        /// <param name="fields">A comma-separated list of fields to include in the response.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("reports/{report_id}.json")]
        public abstract System.Threading.Tasks.Task GetReport(long report_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Updates a report
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("reports/{report_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateReport([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateReportRequest request, long report_id);

        /// <summary>
        /// Deletes a report
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("reports/{report_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteReport(long report_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record ReportOrig
    {
        /// <summary>
        /// The category for the report. When you create a report, the API will return `custom_app_reports`.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("category")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Category { get; set; } = default!;

        /// <summary>
        /// The name of the report. Maximum length: 255 characters.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Name { get; set; } = default!;

        /// <summary>
        /// The ShopifyQL query that generates the report.See [Shopify Query Language](/api/admin/rest/reference/analytics/shopify-ql).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("shopify_ql")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? ShopifyQl { get; set; } = default!;

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