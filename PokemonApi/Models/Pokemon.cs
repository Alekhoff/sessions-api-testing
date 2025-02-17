namespace PokemonApi.Models;

public class Pokemon
{
    public required string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public int Id { get; set; }
    public List<Stats> Stats { get; set; } = [];
}