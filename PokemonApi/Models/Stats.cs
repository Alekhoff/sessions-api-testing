using System.Text.Json.Serialization;

namespace PokemonApi.Models;

public class Stats
{
    [JsonPropertyName("base_stat")]
    public required int BaseStat { get; set; }
    public int Effort { get; set; }
    public required Stat Stat { get; set; }

}