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

    public abstract class DiscountCodeControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Creates a discount code
        /// </summary>
        /// <remarks>
        /// Creates a discount code.
        /// 
        /// The `price_rule_id` path parameter is the ID of the price rule that the discount code will belong to. This is required because each discount code must belong to a price rule.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes.json")]
        public abstract System.Threading.Tasks.Task CreateDiscountCode([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateDiscountCodeRequest request, long price_rule_id);

        /// <summary>
        /// Retrieves a list of discount codes
        /// </summary>
        /// <remarks>
        /// Retrieve a list of discount codes. **Note:** As of version 2019-10, this endpoint implements pagination by using links that are provided in the response header. Sending the `page` parameter will return an error. To learn more, see [*Make paginated requests to the REST Admin API*](/api/usage/pagination-rest).
        /// 
        /// The `price_rule_id` path parameter is the ID of the price rule that the discount codes belongs to.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes.json")]
        public abstract System.Threading.Tasks.Task ListDiscountCodes(long price_rule_id);

        /// <summary>
        /// Updates an existing discount code
        /// </summary>
        /// <remarks>
        /// Updates an existing discount code.
        /// 
        /// The `price_rule_id` path parameter is the ID of the price rule that the discount code belongs to. This is required because each discount code must belong to a price rule.
        /// 
        /// The `discount_code_id` path parameter is the ID of the discount code to update for the associated price rule.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes/{discount_code_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateDiscountCode([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateDiscountCodeRequest request, long discount_code_id, long price_rule_id);

        /// <summary>
        /// Retrieves a single discount code
        /// </summary>
        /// <remarks>
        /// Retrieves a single discount code.
        /// 
        /// The `price_rule_id` path parameter is the ID of the price rule that the discount code belongs to. This is required because each discount code must belong to a price rule.
        /// 
        /// The `discount_code_id` path parameter is the ID of the discount code to retrieve for the associated price rule.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes/{discount_code_id}.json")]
        public abstract System.Threading.Tasks.Task GetDiscountCode(long discount_code_id, long price_rule_id);

        /// <summary>
        /// Deletes a discount code
        /// </summary>
        /// <remarks>
        /// Deletes a discount code.
        /// 
        /// The `price_rule_id` path parameter is the ID of the price rule that the discount code belongs to. This is required because each discount code must belong to a price rule.
        /// 
        /// The `discount_code_id` path parameter is the ID of the discount code to delete for the associated price rule.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes/{discount_code_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteDiscountCode(long discount_code_id, long price_rule_id);

        /// <summary>
        /// Retrieves the location of a discount code
        /// </summary>
        /// <remarks>
        /// Retrieves the location of a discount code.
        /// 
        /// The discount code's location is returned in the location header, not in the DiscountCode object itself. Depending on your HTTP client, the location of the discount code might follow the location header automatically.
        /// </remarks>
        /// <param name="code">Retrieves the location of a discount code by code name.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("discount_codes/lookup.json")]
        public abstract System.Threading.Tasks.Task GetLocationOfDiscountCode([Microsoft.AspNetCore.Mvc.FromQuery] string? code = null);

        /// <summary>
        /// Retrieves a count of discount codes for a shop
        /// </summary>
        /// <param name="times_used">Show discount codes with times used.</param>
        /// <param name="times_used_max">Show discount codes used greater than or equal to this value.</param>
        /// <param name="times_used_min">Show discount codes used less than or equal to this value.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("discount_codes/count.json")]
        public abstract System.Threading.Tasks.Task CountDiscountCodesForShop([Microsoft.AspNetCore.Mvc.FromQuery] int? times_used = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? times_used_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? times_used_min = null);

        /// <summary>
        /// Creates a discount code creation job
        /// </summary>
        /// <remarks>
        /// Creates a discount code creation job.
        /// 
        /// The batch endpoint can be used to asynchronously create up to 100 discount codes in a single request. It enqueues and returns a `discount_code_creation` object that can be monitored for completion. You can enqueue a single creation job per a shop and you can't enqueue more until the job completes.
        /// 
        /// The `price_rule_id` path parameter is the ID of the price rule that the discount code will belong to. This is required because each discount code must belong to a price rule.
        /// 
        /// Response fields that are specific to the batch endpoint include: * `status`: The state of the discount code creation job. Possible values are: * `queued`: The job is acknowledged, but not started. * `running`: The job is in process. * `completed`: The job has finished. * `codes_count`: The number of discount codes to create. * `imported_count`: The number of discount codes created successfully. * `failed_count`: The number of discount codes that were not created successfully. Unsuccessful attempts will retry up to three times. * `logs`: A report that specifies when no discount codes were created because the provided data was invalid. Example responses: * "Price rule target selection can't be blank" * "Price rule allocation method can't be blank"
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/batch.json")]
        public abstract System.Threading.Tasks.Task CreateDiscountCodeCreationJob([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateDiscountCodeCreationJobRequest request, long price_rule_id);

        /// <summary>
        /// Retrieves a discount code creation job
        /// </summary>
        /// <remarks>
        /// Retrieves a discount code creation job
        /// 
        /// The `price_rule_id` path parameter is the ID of the price rule that the discount code creation job was ran for. This is required because each discount code creation job is associated to a price rule.
        /// 
        /// The `batch_id` path parameter is the ID of the discount code creation job for the associated price rule.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/batch/{batch_id}.json")]
        public abstract System.Threading.Tasks.Task GetDiscountCodeCreationJob(long batch_id, long price_rule_id);

        /// <summary>
        /// Retrieves a list of discount codes for a discount code creation job
        /// </summary>
        /// <remarks>
        /// Retrieves a list of discount codes for a discount code creation job.
        /// 
        /// The `price_rule_id` path parameter is the ID of the price rule that the discount code creation job was ran for. This is required because each discount code creation job is associated to a price rule.
        /// 
        /// The `batch_id` path parameter is the ID of the discount code creation job for the associated price rule.
        /// 
        /// Discount codes that have been successfully created include a populated `id` field. Discount codes that encountered errors during the creation process include a populated `errors` field.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/batch/{batch_id}/discount_codes.json")]
        public abstract System.Threading.Tasks.Task ListDiscountCodesForDiscountCodeCreationJob(long batch_id, long price_rule_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record DiscountCodeOrig
    {
        /// <summary>
        /// The case-insensitive discount code that customers use at checkout. (maximum: 255 characters)
        ///  &lt;div class="note note-caution"&gt; 
        /// 
        /// Use the same value for `code` as the `title` property of the associated [price rule](/docs/admin-api/rest/reference/discounts/pricerule/#title-property).
        ///  &lt;/div&gt;
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("code")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Code { get; set; } = default!;

        /// <summary>
        /// The ID for the price rule that this discount code belongs to.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("price_rule_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? PriceRuleId { get; set; } = default!;

        /// <summary>
        /// The number of times that the discount code has been redeemed.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("usage_count")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public int? UsageCount { get; set; } = default!;

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