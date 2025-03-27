using System.ComponentModel.DataAnnotations;

namespace StarWars.Models;

public class PlanetModel
{
    public int Id { get; set; }
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }
    [StringLength(50)]
    public string Climate { get; set; } = string.Empty;
    [StringLength(50)]
    public string Terrain { get; set; } = string.Empty;
    public int Diameter { get; set; }
}