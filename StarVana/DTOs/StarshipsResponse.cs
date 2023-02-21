using System.Text.Json.Serialization;

namespace StarVana.DTOs
{
    public class StarshipsResponse
    {
        [JsonConstructor]
        public StarshipsResponse()
        {
            Results = new List<Starship>();
        }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }

        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Starship> Results { get; }
    }
}
