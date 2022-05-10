using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify transaction.
    /// </summary>
    public class Transaction : ShopifyObject
    {
        /// <summary>
        /// The amount of money that the transaction was for.
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// The authorization code associated with the transaction.
        /// </summary>
        [JsonPropertyName("authorization")]
        public string? Authorization { get; set; }

        /// <summary>
        /// The date and time when the transaction was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The unique identifier for the device.
        /// </summary>
        [JsonPropertyName("device_id")]
        public string? DeviceId { get; set; }

        /// <summary>
        /// The name of the gateway the transaction was issued through.
        /// </summary>
        [JsonPropertyName("gateway")]
        public string? Gateway { get; set; }

        /// <summary>
        /// The origin of the transaction. This is set by Shopify and cannot be overridden. Example values include: 'web', 'pos', 'iphone', 'android'.
        /// </summary>
        [JsonPropertyName("source_name")]
        public string SourceName { get; private set; }

        /// <summary>
        /// The origin of the transaction. Set to "external" to create a cash transaction for the associated order.
        /// </summary>
        [JsonPropertyName("source")]
        public string? Source { get; set; }

        /// <summary>
        /// An object containing information about the credit card used for this transaction.
        /// </summary>
        [JsonPropertyName("payment_details")]
        public PaymentDetails PaymentDetails { get; set; }

        /// <summary>
        /// The kind of transaction. Known values are 'authorization', 'capture', 'sale', 'void' and 'refund'.
        /// </summary>
        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        /// <summary>
        /// A unique numeric identifier for the order.
        /// </summary>
        [JsonPropertyName("order_id")]
        public long? OrderId { get; set; }

        /// <summary>
        /// Shopify does not currently offer documentation for this object.
        /// </summary>
        [JsonPropertyName("receipt")]
        public object Receipt { get; set; }

        /// <summary>
        /// A standardized error code, e.g. 'incorrect_number', independent of the payment provider. Value can be null. A full list of known values can be found at https://help.shopify.com/api/reference/transaction.
        /// </summary>
        [JsonPropertyName("error_code")]
        public string? ErrorCode { get; set; }

        /// <summary>
        /// The status of the transaction. Valid values are: pending, failure, success or error.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Whether the transaction is for testing purposes.
        /// </summary>
        [JsonPropertyName("test")]
        public bool? Test { get; set; }

        /// <summary>
        /// The unique identifier for the user.
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// The three letter code (ISO 4217) for the currency used for the payment.
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("parent_id")]
        public long? ParentId { get; set; }

        /// <summary>
        /// The maximum amount that can be refunded
        /// </summary>
        [JsonPropertyName("maximum_refundable")]
        public decimal? MaximumRefundable { get; set; }

        /// <summary>
        /// An adjustment on the transaction showing the amount lost or gained due to fluctuations in the currency exchange rate
        /// Requires the header X-Shopify-Api-Features = include-currency-exchange-adjustments
        /// </summary>
        [JsonPropertyName("currency_exchange_adjustment")]
        public CurrencyExchangeAdjustment CurrencyExchangeAdjustment { get; set; }
    }
}
