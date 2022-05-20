using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class PriceRuleBase
    {
        ///<summary>
        /// The title of the price rule.
        ///</summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        ///<summary>
        /// The target type the price rule applies to. Known values are "line_item" or "shipping_line".
        ///</summary>
        [JsonPropertyName("target_type")]
        public string? TargetType { get; set; }

        ///<summary>
        /// The target selection method of the price rule. Use all to apply the discount to all line items
        /// in the checkout and use entitled to apply to selected entitlements. Known values are "all" or "entitled".
        ///</summary>
        [JsonPropertyName("target_selection")]
        public string? TargetSelection { get; set; }
        
        ///<summary>
        /// The allocation method of the price rule.
        /// With an allocation method of each, the discount will be applied to each of the entitled items. For example, for a price rule that take $15 off, each entitled line item in a checkout will be discounted by $15.
        /// With an allocation method of across, the calculated discount amount will be applied across the entitled items.For example, for a price rule that takes $15 off, the discount will be applied across all the entitled items.
        /// Currently, if TargetType is shipping_line, then only each is accepted. Known values are "across" or "each".
        ///</summary>
        [JsonPropertyName("allocation_method")]
        public string? AllocationMethod { get; set; }

        ///<summary>
        /// The value type of the price rule. If target_type is shipping_line then only percentage is accepted. Known values are "fixed_amount" or "percentage".
        ///</summary>
        [JsonPropertyName("value_type")]
        public string? ValueType { get; set; }

        ///<summary>
        /// The value of the price rule. If target_type is shipping_line, then only -100 is accepted.
        /// It's important to note that when discounting a resource, the value must be a negative number.
        ///</summary>
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        ///<summary>
        /// The price rule can only be used once per customer (tracked by customer id).
        ///</summary>
        [JsonPropertyName("once_per_customer")]
        public bool? OncePerCustomer { get; set; }

        ///<summary>
        /// The maximum number of times the price rule can be used, per discount code.
        ///</summary>
        [JsonPropertyName("usage_limit")]
        public long? UsageLimit { get; set; }

        ///<summary>
        /// The customer selection for the price rule.A customer selection of all means there are no restrictions
        /// on who's eligible for the price rule. Known values are "all" or "prerequisite".
        ///</summary>
        [JsonPropertyName("customer_selection")]
        public string? CustomerSelection { get; set; }

        ///<summary>
        /// Prerequisite cart subtotal range.
        ///</summary>
        [JsonPropertyName("prerequisite_subtotal_range")]
        public PrerequisiteValueRange? PrerequisiteSubtotalRange { get; set; }

        ///<summary>
        /// Prerequisite shipping cost range.Can only be used when target_type is shipping_line.
        ///</summary>
        [JsonPropertyName("prerequisite_shipping_price_range")]
        public PrerequisiteValueRange? PrerequisiteShippingPriceRange { get; set; }

        ///<summary>
        /// A list of prerequisite customer saved search ids. For the price rule to be applicable,
        /// the customer applying the price rule must be in the group of customers matching the customer saved searches.
        ///</summary>
        [JsonPropertyName("prerequisite_saved_search_ids")]
        public IEnumerable<long>? PrerequisiteSavedSearchIds { get; set; }

        ///<summary>
        /// A list of prerequisite customer ids. For the price rule to be applicable,
        /// the customer applying the price rule must be in the group of customers specified.
        ///</summary>
        [JsonPropertyName("prerequisite_customer_ids")]
        public IEnumerable<long>? PrerequisiteCustomerIds { get; set; }

        ///<summary>
        /// A list of entitled product ids.Can be used in combination with entitled_variant_ids. entitled_product_ids can
        /// only be used in conjunction with target_type set to line_itemif and target_selection set to entitled
        ///</summary>
        [JsonPropertyName("entitled_product_ids")]
        public IEnumerable<long>? EntitledProductIds { get; set; }

        ///<summary>
        /// A list of entitled product variant ids. Can be used in combination with entitled_product_ids.
        /// entitled_variant_ids can only be used in conjunction with target_type set to line_item if and target_selection set to
        /// entitled
        ///</summary>
        [JsonPropertyName("entitled_variant_ids")]
        public IEnumerable<long>? EntitledVariantIds { get; set; }

        ///<summary>
        /// A list of entitled collection ids. Cannot be used in combination with entitled_product_ids nor
        /// entitled_variant_ids. entitled_collection_ids can only be used in conjunction with target_typeset to line_item and
        /// target_selection set to entitled
        ///</summary>
        [JsonPropertyName("entitled_collection_ids")]
        public IEnumerable<long>? EntitledCollectionIds { get; set; }

        ///<summary>
        /// A list of shipping country ids. entitled_country_ids can only be used in conjunction with target_type set to
        /// shipping_line and target_selection set to entitled.
        ///</summary>
        [JsonPropertyName("entitled_country_ids")]
        public IEnumerable<long>? EntitledCountryIds { get; set; }

        ///<summary>
        /// The date and time when the price rule starts.
        ///</summary>
        [JsonPropertyName("starts_at")]
        public DateTimeOffset? StartsAt { get; set; }

        ///<summary>
        /// The date and time when the price rule ends.Must be after starts_at.
        ///</summary>
        [JsonPropertyName("ends_at")]
        public DateTimeOffset? EndsAt { get; set; }

        ///<summary>
        /// The date and time the object was created.
        ///</summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        ///<summary>
        /// The date and time the object was last updated.
        ///</summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        ///<summary>
        /// List of product ids that will be a prerequisites for a Buy X Get Y type discount. The prerequisite_product_ids` can be used only with:
        ///   * `target_type` set to `line_item`
        ///   * `target_selection` set to `entitled`
        ///   * `allocation_method` set to `each`
        ///   * prerequisite_to_entitlement_quantity_ratio` defined
        /// **Caution**
        /// If a product variant is included in `prerequisite_variant_ids`, then `prerequisite_product_ids` can't include the ID of the product associated with that variant.
        /// </summary>
        [JsonPropertyName("prerequisite_product_ids")]
        public IEnumerable<long>? PrerequisiteProductIds { get; set; }

        /// <summary>
        /// List of variant ids that will be a prerequisites for a Buy X Get Y type discount. The `entitled_variant_ids` can be used only with:
        ///   * `target_type` set to `line_item`
        ///   * `target_selection` set to `entitled`
        ///   * `allocation_method` set to `each`
        ///   * `prerequisite_to_entitlement_quantity_ratio` defined
        /// **Caution**
        /// If a product is included in `prerequisite_product_ids`, then `prerequisite_variant_ids` can't include the ID of any variants associated with that product.
        /// </summary>
        [JsonPropertyName("prerequisite_variant_ids")]
        public IEnumerable<long>? PrerequisiteVariantIds { get; set; }
        
        /// <summary>
        /// List of collection ids that will be a prerequisites for a Buy X Get Y discount. The `entitled_collection_ids` can be used only with:
        ///   * `target_type` set to `line_item`
        ///   * `target_selection` set to `entitled`
        ///   * `allocation_method` set to `each`
        ///   * `prerequisite_to_entitlement_quantity_ratio` defined
        /// **Caution**
        /// If a product is included in `prerequisite_product_ids`, then `prerequisite_variant_ids` can't include the ID of any variants associated with that product.
        /// </summary>
        [JsonPropertyName("prerequisite_collection_ids")]
        public IEnumerable<long>? PrerequisiteCollectionIds { get; set; }

        /// <summary>
        /// A list of customer segment IDs. For the price rule to be applicable, the customer must be in the group of customers matching a customer segment.
        /// If `customer_segment_prerequisite_ids` is populated, then `prerequisite_customer_ids` must be empty.
        /// </summary>
        [JsonPropertyName("customer_segment_prerequisite_ids")]
        public IEnumerable<long>? CustomerSegmentPrerequisiteIds { get; set; }

        /// <summary>
        /// The prerequisite purchase for a Buy X Get Y discount.
        /// </summary>
        [JsonPropertyName("prerequisite_to_entitlement_purchase")]
        public PrerequisiteToEntitlementPurchase? PrerequisiteToEntitlementPurchase { get; set; }

        /// <summary>
        /// Buy/Get ratio for a Buy X Get Y discount. The `prerequisite_to_entitlement_quantity_ratio` can be used only with:
        /// * `value_type` set to `percentage`
        /// * `target_type` set to `line_item`
        /// * `target_selection` set to `entitled`
        /// * `allocation_method` set to `each`
        /// * `prerequisite_product_ids`, `prerequisite_variant_ids`, or `prerequisite_collection_ids` defined and `entitled_product_ids`, `entitled_variant_ids`, or `entitled_collection_ids` defined.
        /// **Caution**
        /// Cannot be used in combination with `prerequisite_subtotal_range`, `prerequisite_quantity_range` or `prerequisite_shipping_price_range`.
        /// </summary>
        [JsonPropertyName("prerequisite_to_entitlement_quantity_ratio")]
        public PrerequisiteToEntitlementQuantityRatio? PrerequisiteToEntitlementQuantityRatio { get; set; }

    }

    public class PrerequisiteToEntitlementQuantityRatio
    {
        /// <summary>
        /// The necessary 'buy' quantity.
        /// </summary>
        [JsonPropertyName("prerequisite_quantity")]
        public int PrerequisiteQuantity { get; set; }

        /// <summary>
        /// The offered 'get' quantity.
        /// </summary>
        [JsonPropertyName("entitled_quantity ")]
        public int EntitledQuantity{ get; set; }
    }

    public class PrerequisiteToEntitlementPurchase
    {
        /// <summary>
        /// The minimum purchase amount required to be entitled to the discount.
        /// </summary>
        [JsonPropertyName("prerequisite_amount")]
        public decimal? PrerequisiteAmount { get; set; }
    }
}