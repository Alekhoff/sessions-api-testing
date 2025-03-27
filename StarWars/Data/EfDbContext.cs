using Microsoft.EntityFrameworkCore;
using StarWars.Models;

namespace StarWars.Data;

public class EfDbContext(DbContextOptions<EfDbContext> pOptions) : DbContext(pOptions)
{
    public DbSet<PersonModel> Persons { get; set; }
    public DbSet<PlanetModel> Planets { get; set; }
    // public DbSet<> Starships { get; set; }
    // public DbSet<> Vehicles { get; set; }
    // public DbSet<> Species { get; set; }
    // public DbSet<> Films { get; set; }
    // public DbSet<> Characters { get; set; }
    // public DbSet<> Episodes { get; set; }
    // public DbSet<> Locations { get; set; }
    // public DbSet<> CharacterSpecies { get; set; }
    
    protected override void OnModelCreating(ModelBuilder pModelBuilder)
    {
        pModelBuilder.Entity<PersonModel>()
            .HasOne(pEntity => pEntity.Homeworld)
            .WithMany()
            .HasForeignKey(p => p.PlanetId)
            .IsRequired(false);
    }
}