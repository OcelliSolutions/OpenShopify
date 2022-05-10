using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models 
{
    public class DraftOrderInvoice
    {
        [JsonPropertyName("to")]            
        public string? To { get; set; }

        [JsonPropertyName("from")]    
        public string? From { get; set; }

        [JsonPropertyName("bcc")]    
        public IEnumerable<string> BCC { get; set; }

        [JsonPropertyName("subject")]    
        public string? Subject { get; set; }

        [JsonPropertyName("custom_message")]    
        public string? CustomMessage { get; set; }
    }
}