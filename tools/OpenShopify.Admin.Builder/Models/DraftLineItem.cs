

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record DraftLineItem : LineItem 
    {
        /// <summary>
        ///  Indicates if this is a product variant line item, or a custom line item. If set to true indicates a custom line item. If set to false indicates a product variant line item. This is a read only field.
        /// </summary>
        [JsonPropertyName("custom")]
        public bool? Custom { get; set; }

        /// <summary>
        /// Discount which will be applied to the line item or the overall order. 
        /// </summary>
        [JsonPropertyName("applied_discount")]
        public AppliedDiscount? AppliedDiscount { get; set; }
    }
}