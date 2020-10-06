using Microsoft.EntityFrameworkCore;

namespace Animal_Shelter.Models
{
  public class Animal_ShelterContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; } //Does this grab the table with all the columns? 

    public Animal_ShelterContext(DbContextOptions options) : base(options) { }
  }
}