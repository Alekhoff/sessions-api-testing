namespace ConsoleApp.Models;

public class ItemModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Rarity { get; set; }
    public int Value { get; set; }
    public int CarryLimit { get; set; }

}