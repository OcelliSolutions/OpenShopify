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

    public abstract class PriceRuleControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Creates a price rule
        /// </summary>
        /// <returns>Creates a price rule</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/price_rules.json")]
        public abstract System.Threading.Tasks.Task CreatePriceRule();

        /// <summary>
        /// Retrieves a list of price rules
        /// </summary>
        /// <param name="created_at_max">Show price rules created before date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="created_at_min">Show price rules created after date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="ends_at_max">Show price rules ending before date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="ends_at_min">Show price rules ending after date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="limit">The maximum number of results to retrieve.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        /// <param name="starts_at_max">Show price rules starting before date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="starts_at_min">Show price rules starting after date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="times_used">Show price rules with times used.</param>
        /// <param name="updated_at_max">Show price rules last updated before date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="updated_at_min">Show price rules last updated after date (format 2017-03-25T16:15:47-04:00).</param>
        /// <returns>Retrieves a list of price rules</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/price_rules.json")]
        public abstract System.Threading.Tasks.Task RetrieveListOfPriceRules([Microsoft.AspNetCore.Mvc.FromQuery] string? created_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? created_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? ends_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? ends_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? limit = "50", [Microsoft.AspNetCore.Mvc.FromQuery] string? since_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? starts_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? starts_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? times_used = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? updated_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? updated_at_min = null);

        /// <summary>
        /// Updates an existing a price rule
        /// </summary>
        /// <returns>Updates an existing a price rule</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/price_rules/{price_rule_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateExistingPriceRule(string price_rule_id);

        /// <summary>
        /// Retrieves a single price rule
        /// </summary>
        /// <returns>Retrieves a single price rule</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/price_rules/{price_rule_id}.json")]
        public abstract System.Threading.Tasks.Task RetrieveSinglePriceRule(string price_rule_id);

        /// <summary>
        /// Remove an existing PriceRule
        /// </summary>
        /// <returns>Remove an existing PriceRule</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/price_rules/{price_rule_id}.json")]
        public abstract System.Threading.Tasks.Task RemoveExistingPricerule(string price_rule_id);

        /// <summary>
        /// Retrieves a count of all price rules
        /// </summary>
        /// <returns>Retrieves a count of all price rules</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/price_rules/count.json")]
        public abstract System.Threading.Tasks.Task RetrieveCountOfAllPriceRules();

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PriceRule
    {
        /// <summary>
        /// The allocation method of the price rule. Valid values:
        /// <br/> 
        /// <br/> each: The discount is applied to each of the entitled items. For example, for a price rule that takes $15 off,
        /// <br/> each entitled line item in a checkout will be discounted by $15.
        /// <br/> across: The calculated discount amount will be applied across the entitled items. For example, for a price rule
        /// <br/> that takes $15 off, the discount will be applied across all the entitled items.
        /// <br/> 
        /// <br/> When the value of target_type is shipping_line, then this value must be each.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("allocation_method")]
        public string? Allocation_method { get; set; } = default!;

        /// <summary>
        /// The date and time (ISO 8601 format) when the price rule was created.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("created_at")]
        public string? Created_at { get; set; } = default!;

        /// <summary>
        /// The date and time (ISO 8601 format) when the price rule was updated.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
        public string? Updated_at { get; set; } = default!;

        /// <summary>
        /// The customer selection for the price rule. Valid values:
        /// <br/> 
        /// <br/> all: The price rule is valid for all customers.
        /// <br/> prerequisite: The customer must either belong to one of the customer segments specified by customer_segment_prerequisite_ids, or be one of the customers specified by prerequisite_customer_ids.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("customer_selection")]
        public string? Customer_selection { get; set; } = default!;

        /// <summary>
        /// The date and time (ISO 8601  format) when the price rule ends. Must be after starts_at.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("ends_at")]
        public string? Ends_at { get; set; } = default!;

        /// <summary>
        /// A list of IDs of collections whose products will be eligible to the discount. It can be used only with
        /// <br/> target_type set to line_item and target_selection set to entitled.
        /// <br/> It can't be used in combination with entitled_product_ids or entitled_variant_ids.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("entitled_collection_ids")]
        public string? Entitled_collection_ids { get; set; } = default!;

        /// <summary>
        /// A list of IDs of shipping countries that will be entitled to the discount. It can be used only with target_type set to shipping_line and target_selection set to entitled.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("entitled_country_ids")]
        public string? Entitled_country_ids { get; set; } = default!;

        /// <summary>
        /// A list of IDs of products that will be entitled to the discount. It can be used only with target_type set to line_item
        /// <br/> and target_selection set to entitled.
        /// <br/> 
        /// <br/> If a product variant is included in entitled_variant_ids, then entitled_product_ids can't include the ID of the product associated with that variant.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("entitled_product_ids")]
        public string? Entitled_product_ids { get; set; } = default!;

        /// <summary>
        /// A list of IDs of product variants that will be entitled to the discount. It can be used only with target_type set to line_item
        /// <br/> and target_selection set to entitled.
        /// <br/> 
        /// <br/> If a product is included in entitled_product_ids, then entitled_variant_ids can't include the ID of any variants associated with that product.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("entitled_variant_ids")]
        public string? Entitled_variant_ids { get; set; } = default!;

        /// <summary>
        /// The ID for the price rule.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; } = default!;

        /// <summary>
        /// Whether the generated discount code will be valid only for a single use per customer. This is tracked using customer ID.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("once_per_customer")]
        public string? Once_per_customer { get; set; } = default!;

        /// <summary>
        /// A list of customer IDs. For the price rule to be applicable, the customer must match one of the specified customers.
        /// <br/> If prerequisite_customer_ids is populated, then customer_segment_prerequisite_ids must be empty.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("prerequisite_customer_ids")]
        public string? Prerequisite_customer_ids { get; set; } = default!;

        /// <summary>
        /// The minimum number of items for the price rule to be applicable. It has the following property:
        /// <br/> 
        /// <br/> greater_than_or_equal_to: The quantity of an entitled cart item must be greater than or equal to this value.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("prerequisite_quantity_range")]
        public string? Prerequisite_quantity_range { get; set; } = default!;

        /// <summary>
        /// A list of customer segment IDs. For the price rule to be applicable, the customer must be in the group of customers matching a customer segment.
        /// <br/> If customer_segment_prerequisite_ids is populated, then prerequisite_customer_ids must be empty.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("customer_segment_prerequisite_ids")]
        public string? Customer_segment_prerequisite_ids { get; set; } = default!;

        /// <summary>
        /// The maximum shipping price for the price rule to be applicable. It has the following property:
        /// <br/> 
        /// <br/> less_than_or_equal_to: The shipping price must be less than or equal to this value.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("prerequisite_shipping_price_range")]
        public string? Prerequisite_shipping_price_range { get; set; } = default!;

        /// <summary>
        /// The minimum subtotal for the price rule to be applicable. It has the following property:
        /// <br/> 
        /// <br/> greater_than_or_equal_to: The subtotal of the entitled cart items must be greater than or equal to this value for the discount to apply.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("prerequisite_subtotal_range")]
        public string? Prerequisite_subtotal_range { get; set; } = default!;

        /// <summary>
        /// The prerequisite purchase for a Buy X Get Y discount. It has the following property:
        /// <br/> 
        /// <br/> prerequisite_amount: The minimum purchase amount required to be entitled to the discount.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("prerequisite_to_entitlement_purchase")]
        public string? Prerequisite_to_entitlement_purchase { get; set; } = default!;

        /// <summary>
        /// The date and time (ISO 8601 format) when the price rule starts.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("starts_at")]
        public string? Starts_at { get; set; } = default!;

        /// <summary>
        /// The target selection method of the price rule. Valid values:
        /// <br/> 
        /// <br/> all: The price rule applies the discount to all line items in the checkout.
        /// <br/> entitled: The price rule applies the discount to selected entitlements only.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("target_selection")]
        public string? Target_selection { get; set; } = default!;

        /// <summary>
        /// The target type that the price rule applies to. Valid values:
        /// <br/> 
        /// <br/> line_item: The price rule applies to the cart's line items.
        /// <br/> shipping_line: The price rule applies to the cart's shipping lines.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("target_type")]
        public string? Target_type { get; set; } = default!;

        /// <summary>
        /// The title of the price rule. This is used by the Shopify admin search to retrieve discounts. It is also displayed on the Discounts page of the Shopify admin for bulk discounts.
        /// <br/> For non-bulk discounts, the discount code is displayed on the admin.
        /// <br/> 
        /// <br/> For a consistent search experience, use the same value for title as the code property of the associated discount code.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("title")]
        public string? Title { get; set; } = default!;

        /// <summary>
        /// The maximum number of times the price rule can be used, per discount code.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("usage_limit")]
        public string? Usage_limit { get; set; } = default!;

        /// <summary>
        /// List of product ids that will be a prerequisites for a Buy X Get Y type discount. The prerequisite_product_ids can be used only with:
        /// <br/> 
        /// <br/> target_type set to line_item,
        /// <br/> target_selection set to entitled,
        /// <br/> allocation_method set to each and
        /// <br/> prerequisite_to_entitlement_quantity_ratio defined.
        /// <br/> 
        /// <br/> 
        /// <br/> Caution
        /// <br/> If a product variant is included in prerequisite_variant_ids, then prerequisite_product_ids can't include the ID of the product associated with that variant.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("prerequisite_product_ids")]
        public string? Prerequisite_product_ids { get; set; } = default!;

        /// <summary>
        /// List of variant ids that will be a prerequisites for a Buy X Get Y type discount. The entitled_variant_ids can be used only with:
        /// <br/> 
        /// <br/> target_type set to line_item,
        /// <br/> target_selection set to entitled,
        /// <br/> allocation_method set to each and
        /// <br/> prerequisite_to_entitlement_quantity_ratio defined.
        /// <br/> 
        /// <br/> 
        /// <br/> Caution
        /// <br/> If a product is included in prerequisite_product_ids, then prerequisite_variant_ids can't include the ID of any variants associated with that product.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("prerequisite_variant_ids")]
        public string? Prerequisite_variant_ids { get; set; } = default!;

        /// <summary>
        /// List of collection ids that will be a prerequisites for a Buy X Get Y discount. The entitled_collection_ids can be used only with:
        /// <br/> 
        /// <br/> target_type set to line_item,
        /// <br/> target_selection set to entitled,
        /// <br/> allocation_method set to each and
        /// <br/> prerequisite_to_entitlement_quantity_ratio defined.
        /// <br/> 
        /// <br/> Cannot be used in combination with prerequisite_product_ids or prerequisite_variant_ids.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("prerequisite_collection_ids")]
        public string? Prerequisite_collection_ids { get; set; } = default!;

        /// <summary>
        /// The value of the price rule. If if the value of target_type is shipping_line, then only -100 is accepted.
        /// <br/> The value must be negative.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public string? Value { get; set; } = default!;

        /// <summary>
        /// The value type of the price rule. Valid values:
        /// <br/> 
        /// <br/> fixed_amount: Applies a discount of value as a unit of the store's currency. For example, if value is -30 and the store's currency is USD,
        /// <br/> then $30 USD is deducted when the discount is applied.
        /// <br/> percentage: Applies a percentage discount of value. For example, if value is -30, then 30% will be deducted when the discount is applied.
        /// <br/> 
        /// <br/> If target_type is shipping_line, then only percentage is accepted.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("value_type")]
        public string? Value_type { get; set; } = default!;

        /// <summary>
        /// Buy/Get ratio for a Buy X Get Y discount. prerequisite_quantity defines the necessary 'buy' quantity and entitled_quantity the offered 'get' quantity.
        /// <br/> The prerequisite_to_entitlement_quantity_ratio can be used only with:
        /// <br/> 
        /// <br/> value_type set to percentage,
        /// <br/> target_type set to line_item,
        /// <br/> target_selection set to entitled,
        /// <br/> allocation_method set to each,
        /// <br/> prerequisite_product_ids or prerequisite_variant_ids or prerequisite_collection_ids defined and
        /// <br/> entitled_product_ids or entitled_variant_ids or entitled_collection_ids defined.
        /// <br/> 
        /// <br/> 
        /// <br/> Caution
        /// <br/> Cannot be used in combination with prerequisite_subtotal_range, prerequisite_quantity_range or prerequisite_shipping_price_range.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("prerequisite_to_entitlement_quantity_ratio")]
        public string? Prerequisite_to_entitlement_quantity_ratio { get; set; } = default!;

        /// <summary>
        /// The number of times the discount can be allocated on the cart - if eligible. For example a Buy 1 hat Get 1 hat for free discount can be applied 3 times on a cart having more than 6 hats, where maximum of 3 hats get discounted - if the allocation_limit is 3. Empty (null) allocation_limit means unlimited number of allocations.
        /// <br/> 
        /// <br/> Caution
        /// <br/> allocation_limit is only working with Buy X Get Y discount. The default value on creation will be null (unlimited).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("allocation_limit")]
        public string? Allocation_limit { get; set; } = default!;

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