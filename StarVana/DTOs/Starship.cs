using System.Text.Json.Serialization;

namespace StarVana.DTOs
{
    public class Starship
    {
        [JsonConstructor]
        public Starship()
        {
            Pilots = new List<string>();
            Films = new List<string>();
        }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("manufacturer")]
        public string? Manufacturer { get; set; }

        [JsonPropertyName("costincredits")]
        public string? CostInCredits { get; set; }

        [JsonPropertyName("length")]
        public string? Length { get; set; }

        [JsonPropertyName("maxatmospheringspeed")]
        public string? MaxAtmospheringSpeed { get; set; }

        [JsonPropertyName("crew")]
        public string? Crew { get; set; }

        [JsonPropertyName("passengers")]
        public string? Passengers { get; set; }

        [JsonPropertyName("cargocapacity")]
        public string? CargoCapacity { get; set; }

        [JsonPropertyName("consumables")]
        public string? Consumables { get; set; }

        [JsonPropertyName("hyperdriverating")]
        public string? HyperdriveRating { get; set; }

        [JsonPropertyName("MGLT")]
        public string? MGLT { get; set; }

        [JsonPropertyName("starshipclass")]
        public string? StarshipClass { get; set; }

        [JsonPropertyName("pilots")]
        public List<string> Pilots { get; }

        [JsonPropertyName("films")]
        public List<string> Films { get; }

        [JsonPropertyName("created")]
        public string? Created { get; set; }

        [JsonPropertyName("edited")]
        public string? Edited { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

    }
}
