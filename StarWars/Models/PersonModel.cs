using System.ComponentModel.DataAnnotations;

namespace StarWars.Models;

public class PersonModel
{
    public int Id { get; set; }
    [StringLength(255)]
    public required string Name { get; set; }
    public int? Height { get; set; }
    public int? Mass { get; set; }
    [StringLength(50)]
    public string? HairColor { get; set; } = string.Empty;
    [StringLength(50)]
    public string? SkinColor { get; set; } = string.Empty;
    [StringLength(50)]
    public string? EyeColor { get; set; } = string.Empty;
    [StringLength(50)]
    public string? Gender { get; set; } = string.Empty;
    public int? PlanetId { get; set; }
    public string? Homeworld { get; set; } = string.Empty;
    public PlanetModel HomeworldDetails { get; set; } = null!;
}