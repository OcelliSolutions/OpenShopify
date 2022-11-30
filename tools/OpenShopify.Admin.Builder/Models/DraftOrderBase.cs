using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record DraftOrderBase
    {
        /// <inheritdoc cref="DraftOrderOrig.Customer"/>
        [JsonPropertyName("customer")]
        public new Customer? Customer { get; set; }


        /// <inheritdoc cref="DraftOrderOrig.ShippingAddress"/>
        [JsonPropertyName("shipping_address")]
        public new Address? ShippingAddress { get; set; }

        /// <inheritdoc cref="DraftOrderOrig.BillingAddress"/>
        [JsonPropertyName("billing_address")]
        public new Address? BillingAddress { get; set; }

        /// <inheritdoc cref="DraftOrderOrig.NoteAttributes"/>
        [JsonPropertyName("note_attributes")]
        public new IEnumerable<NoteAttribute>? NoteAttributes { get; set; }

        /// <inheritdoc cref="DraftOrderOrig.LineItems"/>
        [JsonPropertyName("line_items")]
        public new IEnumerable<DraftLineItem>? LineItems { get; set; }

        /// <inheritdoc cref="DraftOrderOrig.ShippingLine"/>
        [JsonPropertyName("shipping_line")]
        public new DraftShippingLine? ShippingLine { get; set; }

        /// <inheritdoc cref="DraftOrderOrig.TaxLines"/>
        [JsonPropertyName("tax_lines")]
        public new IEnumerable<TaxLine>? TaxLines { get; set; }

        /// <inheritdoc cref="DraftOrderOrig.AppliedDiscount"/>
        [JsonPropertyName("applied_discount")]
        public new AppliedDiscount? AppliedDiscount { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="DraftOrder"/>. Note: This is not naturally returned with a <see cref="DraftOrder"/> response, as
        /// Shopify will not return <see cref="DraftOrder"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldService"/>. 
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<Metafield>? Metafields { get; set; }

        /// <summary>
        /// An optional boolean that you can send as part of a draft order object to load customer shipping information.
        /// </summary>
        [JsonPropertyName("use_customer_default_address")]
        public bool? UseCustomerDefaultAddress { get; set; }

        /// <inheritdoc cref="DraftOrderOrig.Status"/>
        [JsonPropertyName("status")]
        public new DraftOrderStatus? Status { get; set; }

        /// <inheritdoc cref="DraftOrderOrig.TaxExemptions"/>
        [JsonPropertyName("tax_exemptions")]
        public new List<DraftOrderTaxExemptions>? TaxExemptions { get; set; }
    }
}
