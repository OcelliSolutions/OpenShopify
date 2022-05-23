using System.Text.Json.Serialization;

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
}

public partial record PrerequisiteToEntitlementQuantityRatio
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
    public int EntitledQuantity { get; set; }
}

public partial record PrerequisiteToEntitlementPurchase
{
    /// <summary>
    /// The minimum purchase amount required to be entitled to the discount.
    /// </summary>
    [JsonPropertyName("prerequisite_amount")]
    public decimal? PrerequisiteAmount { get; set; }
}