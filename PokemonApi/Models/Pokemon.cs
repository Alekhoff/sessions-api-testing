namespace PokemonApi.Models;

public class Pokemon ()
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<Stats> Stats { get; set; } = [];

 
}
