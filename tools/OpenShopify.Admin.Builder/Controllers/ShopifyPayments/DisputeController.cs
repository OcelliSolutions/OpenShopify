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

    public abstract class DisputeControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Return a list of all disputes
        /// </summary>
        /// <remarks>
        /// Retrieve all disputes ordered by `initiated_at` date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format), with the most recent being first. **Note:** As of version 2019-10, this endpoint implements pagination by using links that are provided in the response header. Sending the `page` parameter will return an error. To learn more, see [*Make paginated requests to the REST Admin API*](/api/usage/pagination-rest).
        /// </remarks>
        /// <param name="initiated_at">Return only disputes with the specified `initiated_at` date ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format).</param>
        /// <param name="last_id">Return only disputes before the specified ID.</param>
        /// <param name="since_id">Return only disputes after the specified ID.</param>
        /// <param name="status">Return only disputes with the specified status.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("shopify_payments/disputes.json")]
        public abstract System.Threading.Tasks.Task ListDisputes([Microsoft.AspNetCore.Mvc.FromQuery] string? initiated_at = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? last_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? status = null);

        /// <summary>
        /// Return a single dispute
        /// </summary>
        /// <remarks>
        /// Retrieves a single dispute by ID.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("shopify_payments/disputes/{dispute_id}.json")]
        public abstract System.Threading.Tasks.Task GetDispute(long dispute_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record DisputeOrig
    {
        /// <summary>
        /// The ID of the order that the dispute belongs to.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("order_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? OrderId { get; set; } = default!;

        /// <summary>
        /// Whether the dispute is still in the inquiry phase or has turned into a chargeback. Valid values: 
        /// 
        /// *   **inquiry**: The dispute is in the inquiry phase. 
        /// *   **chargeback**: The dispute has turned into a chargeback.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Type { get; set; } = default!;

        /// <summary>
        /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) currency code of the dispute amount.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("currency")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Currency { get; set; } = default!;

        /// <summary>
        /// The total amount disputed by the cardholder.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("amount")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public decimal? Amount { get; set; } = default!;

        /// <summary>
        /// The reason of the dispute provided by the cardholder's bank. Valid values: 
        /// 
        /// *   **bank_not_process**: The customer's bank cannot process the charge. 
        /// *   **credit_not_processed**: The customer claims that the purchased product was returned or the transaction was otherwise canceled, but the merchant have not yet provided a refund or credit.  
        /// *   **customer_initiated**: The customer initiated the dispute, so the merchant should contact the customer for additional details to find out why the payment was disputed.  
        /// *   **debit_not_authorized**: The customer's bank cannot proceed with the debit since it has not been authorized.  
        /// *   **duplicate**: The customer claims they were charged multiple times for the same product or service.  
        /// *   **fraudulent**: The cardholder claims that they didn't authorize the payment. 
        /// *   **general**: The dispute is uncategorized, so the merchant should contact the customer for additional details to find out why the payment was disputed.  
        /// *   **incorrect_account_details**: The customer account associated with the purchase is incorrect.  
        /// *   **insufficient_funds**: The customer's bank account has insufficient funds. 
        /// *   **product_not_received**: The customer claims they did not receive the products or services purchased.  
        /// *   **product_unacceptable**: The product or service was received but was defective, damaged, or not as described.  
        /// *   **subscription_canceled**: The customer claims that the merchant continued to charge them after a subscription was canceled.  
        /// *   **unrecognized**: The customer doesn't recognize the payment appearing on their card statement.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("reason")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Reason { get; set; } = default!;

        /// <summary>
        /// The reason for the dispute provided by the cardholder's bank.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("network_reason_code")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? NetworkReasonCode { get; set; } = default!;

        /// <summary>
        /// The current state of the dispute. Valid values: 
        /// 
        /// *   **needs_response**: The dispute has been open and needs an evidence submission. 
        /// *   **under_review**: The evidence has been submitted and is being reviewed by the cardholder's bank.  
        /// *   **charge_refunded**: The merchant refunded the inquiry amount. 
        /// *   **accepted**: The merchant has accepted the dispute as being valid. 
        /// *   **won**: The cardholder's bank reached a final decision in the merchant's favor. 
        /// *   **lost**: The cardholder's bank reached a final decision in the buyer's favor.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("status")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Status { get; set; } = default!;

        /// <summary>
        /// The deadline for evidence submission.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("evidence_due_by")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? EvidenceDueBy { get; set; } = default!;

        /// <summary>
        /// "The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when evidence was sent. Returns `null` if evidence has not yet been sent.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("evidence_sent_on")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? EvidenceSentOn { get; set; } = default!;

        /// <summary>
        /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when this dispute was resolved. Returns `null` if the dispute is not yet resolved.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("finalized_on")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? FinalizedOn { get; set; } = default!;

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