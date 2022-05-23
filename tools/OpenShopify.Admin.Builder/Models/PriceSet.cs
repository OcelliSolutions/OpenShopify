

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record PriceSet
    {
        [JsonPropertyName("shop_money")]
        public Price? ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public Price? PresentmentMoney { get; set; }
    }
}