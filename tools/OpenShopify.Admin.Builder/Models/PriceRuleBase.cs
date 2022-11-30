using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record PriceRuleBase
{
    /// <inheritdoc cref="PriceRuleOrig.Value"/>
    [JsonPropertyName("value")]
    public new decimal? Value { get; set; }
    /// <inheritdoc cref="PriceRuleOrig.PrerequisiteSubtotalRange"/>
    [JsonPropertyName("prerequisite_subtotal_range")]
    public new PrerequisiteValueRange? PrerequisiteSubtotalRange { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.PrerequisiteShippingPriceRange"/>
    [JsonPropertyName("prerequisite_shipping_price_range")]
    public new PrerequisiteValueRange? PrerequisiteShippingPriceRange { get; set; }
    /*
    ///<summary>
    /// A list of prerequisite customer saved search ids. For the price rule to be applicable,
    /// the customer applying the price rule must be in the group of customers matching the customer saved searches.
    ///</summary>
    [JsonPropertyName("prerequisite_saved_search_ids")]
    public List<long>? PrerequisiteSavedSearchIds { get; set; }
    
    /// <inheritdoc cref="PriceRuleOrig.PrerequisiteCustomerIds"/>
    [JsonPropertyName("prerequisite_customer_ids")]
    public new List<long>? PrerequisiteCustomerIds { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.EntitledProductIds"/>
    [JsonPropertyName("entitles_product_ids")]
    public new List<long>? EntitledProductIds { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.EntitledVariantIds"/>
    [JsonPropertyName("entitles_variant_ids")]
    public new List<long>? EntitledVariantIds { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.EntitledCollectionIds"/>
    [JsonPropertyName("entitles_collection_ids")]
    public new List<long>? EntitledCollectionIds { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.EntitledCountryIds"/>
    [JsonPropertyName("entitles_country_ids")]
    public new List<long>? EntitledCountryIds { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.PrerequisiteProductIds"/>
    [JsonPropertyName("prerequisite_product_ids")]
    public new List<long>? PrerequisiteProductIds { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.PrerequisiteVariantIds"/>
    [JsonPropertyName("prerequisite_variant_ids")]
    public new List<long>? PrerequisiteVariantIds { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.PrerequisiteCollectionIds"/>
    [JsonPropertyName("prerequisite_collection_ids")]
    public new List<long>? PrerequisiteCollectionIds { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.CustomerSegmentPrerequisiteIds"/>
    [JsonPropertyName("customer_segment_prerequisite_ids")]
    public new List<long>? CustomerSegmentPrerequisiteIds { get; set; }
    */
    /// <inheritdoc cref="PriceRuleOrig.PrerequisiteToEntitlementPurchase"/>
    [JsonPropertyName("prerequisite_to_entitlement_purchase")]
    public new PrerequisiteToEntitlementPurchase? PrerequisiteToEntitlementPurchase { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.PrerequisiteToEntitlementQuantityRatio"/>
    [JsonPropertyName("prerequisite_to_entitlement_quantity_ratio")]
    public new PrerequisiteToEntitlementQuantityRatio? PrerequisiteToEntitlementQuantityRatio { get; set; }

    /// <inheritdoc cref="PriceRuleOrig.AllocationMethod"/>
    [JsonPropertyName("allocation_method")]
    public new PriceRuleAllocationMethod? AllocationMethod { get; set; } = default!;

    /// <inheritdoc cref="PriceRuleOrig.CustomerSelection"/>
    [JsonPropertyName("customer_selection")]
    public new PriceRuleCustomerSelection? CustomerSelection { get; set; } = default!;


    /// <inheritdoc cref="PriceRuleOrig.TargetSelection"/>
    [JsonPropertyName("target_selection")]
    public new PriceRuleTargetSelection? TargetSelection { get; set; } = default!;

    /// <inheritdoc cref="PriceRuleOrig.TargetType"/>
    [JsonPropertyName("target_type")]
    public new PriceRuleTargetType? TargetType { get; set; } = default!;

    /// <inheritdoc cref="PriceRuleOrig.TargetType"/>
    [JsonPropertyName("value_type")]
    public new PriceRuleValueType? ValueType { get; set; } = default!;
}