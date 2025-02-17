using System.Text.Json.Serialization;

namespace PokemonApi.Models;

public class Stat
{
  public required string Name { get; set; }
  public required string Url { get; set; }
}