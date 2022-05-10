

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class PriceSet
    {
        [JsonPropertyName("shop_money")]
        public Price ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public Price PresentmentMoney { get; set; }
    }
}