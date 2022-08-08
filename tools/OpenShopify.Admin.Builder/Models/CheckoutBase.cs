using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record CheckoutBase
    {
        /// <inheritdoc cref="CheckoutOrig.Token" />
        [JsonPropertyName("token"), Required]
        public new string Token { get; set; } = default!;

        /// <summary>
        /// The full recovery URL to be sent to a customer to recover their abandoned checkout.
        /// </summary>
        [JsonPropertyName("abandoned_checkout_url")]
        public string? AbandonedCheckoutUrl { get; set; }

        /// <inheritdoc cref="CheckoutOrig.BillingAddress"/>
        [JsonPropertyName("billing_address")]
        public new Address? BillingAddress { get; set; }
        
        /// <summary>
        /// Unique identifier for a particular cart that is attached to a particular order.
        /// </summary>
        [JsonPropertyName("cart_token")]
        public string? CartToken { get; set; }
        
        /// <summary>
        /// The date and time when the abandoned cart was completed. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("closed_at")]
        public DateTimeOffset? ClosedAt { get; set; }
        
        /// <summary>
        /// The date and time when the abandoned cart was last modified. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("completed_at")]
        public DateTimeOffset? CompletedAt { get; set; }
        
        /// <summary>
        /// Information about the customer.
        /// </summary>
        [JsonPropertyName("customer")]
        public Customer? Customer { get; set; }
        
        /// <summary>
        /// The two or three-letter language code, optionally followed by a region modifier. Example values: en, en-CA. 
        /// </summary>
        [JsonPropertyName("customer_locale")]
        public string? CustomerLocale { get; set; }
        
        /// <summary>
        /// The ID of the Shopify POS device that created the checkout.
        /// </summary>
        [JsonPropertyName("device_id")]
        public long? DeviceId { get; set; }
        
        /// <summary>
        /// Applicable discount codes that can be applied to the order. If no codes exist the value will default to blank. 
        /// </summary>
        [JsonPropertyName("discount_codes")]
        public IEnumerable<DiscountCode>? DiscountCodes { get; set; }
        
        /// <summary>
        /// The payment gateway used.
        /// </summary>
        [JsonPropertyName("gateway")]
        public string? Gateway { get; set; }
        
        /// <summary>
        /// The URL for the page where the buyer landed when entering the shop.
        /// </summary>
        [JsonPropertyName("landing_site")]
        public string? LandingSite { get; set; }

        /// <inheritdoc cref="CheckoutOrig.LineItems"/>
        [JsonPropertyName("line_items"), Required]
        public new IEnumerable<CheckoutLineItem> LineItems { get; set; } = null!;

        /// <summary>
        /// The ID of the physical location where the checkout was processed.
        /// </summary>
        [JsonPropertyName("location_id")]
        public long? LocationId { get; set; }
        
        /// <summary>
        /// The text of an optional note that a shop owner can attach to the order.
        /// </summary>
        [JsonPropertyName("note")]
        public string? Note { get; set; }

        /// <inheritdoc cref="CheckoutOrig.ShippingAddress"/>
        [JsonPropertyName("shipping_address")]
        public new Address? ShippingAddress { get; set; }

        /// <summary>
        /// A shipping line object, which details the shipping method used.
        /// </summary>
        [JsonPropertyName("shipping_line")]
        public new ShippingLine? ShippingLine { get; set; }

        /// <summary>
        /// An array of shipping line objects, each of which details the shipping methods used.
        /// </summary>
        [JsonPropertyName("shipping_lines")]
        public IEnumerable<ShippingLine>? ShippingLines { get; set; }

        /// <inheritdoc cref="CheckoutOrig.TaxLines"/>
        [JsonPropertyName("tax_lines")]
        public new IEnumerable<TaxLine>? TaxLines { get; set; }
        
        /// <summary>
        /// The total amount of the discounts to be applied to the price of the order.
        /// </summary>
        [JsonPropertyName("total_discounts")]
        public decimal? TotalDiscounts { get; set; }

        /// <summary>
        /// The total duties of the checkout in presentment currency.
        /// </summary>
        [JsonPropertyName("total_duties")]
        public decimal? TotalDuties { get; set; }

        /// <summary>
        /// The sum of all the prices of all the items in the order.
        /// </summary>
        [JsonPropertyName("total_line_items_price")]
        public decimal? TotalLineItemsPrice { get; set; }

        /// <summary>
        /// The sum of all the weights of the line items in the order, in grams.
        /// </summary>
        [JsonPropertyName("total_weight")]
        public decimal? TotalWeight { get; set; }

        /// <inheritdoc cref="CheckoutOrig.ReservationTimeLeft"/>
        [JsonPropertyName("reservation_time_left")]
        [Obsolete]
        public new long? ReservationTimeLeft { get; set; }

        /// <inheritdoc cref="CheckoutOrig.GiftCards"/>
        [JsonPropertyName("gift_cards")]
        public new IEnumerable<CheckoutGiftCard>? GiftCards { get; set; } = default!;

        /// <summary>
        /// Undocumented
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Undocumented
        /// </summary>
        [JsonPropertyName("note_attributes")]
        public IEnumerable<NoteAttribute>? NoteAttributes { get; set; }

        /// <summary>
        /// Undocumented
        /// </summary>
        [JsonPropertyName("payments")]
        public IEnumerable<string>? Payments { get; set; }

        /// <summary>
        /// Undocumented
        /// </summary>
        [JsonPropertyName("tax_exempt")]
        public bool? TaxExempt { get; set; }

        /// <summary>
        /// Undocumented
        /// </summary>
        [JsonPropertyName("total_tip_received")]
        public decimal? TotalTipReceived { get; set; }

        /// <summary>
        /// Undocumented
        /// </summary>
        [JsonPropertyName("tax_manipulations")]
        public IEnumerable<string>? TaxManipulations { get; set; }

        /// <summary>
        /// Undocumented
        /// </summary>
        [JsonPropertyName("shipping_rate")]
        public new ShippingRate? ShippingRate { get; set; }

        /// <summary>
        /// Undocumented
        /// </summary>
        [JsonPropertyName("shipping_rates")]
        public IEnumerable<ShippingRate>? ShippingRates { get; set; }

        /// <summary>
        /// Undocumented
        /// </summary>
        [JsonPropertyName("buyer_accepts_sms_marketing")]
        public bool? BuyerAcceptsSmsMarketing { get; set; }
    }
}
