using Animals.Configuration;
using Animals.Models;
using Microsoft.EntityFrameworkCore;

namespace Animals.Data
{
    public class AnimalsContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalClass> AnimalClass { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Procedure> Procedure { get; set; }
        public DbSet<ProcedureAnimal> ProcedureAnimal { get; set; }

        public AnimalsContext(DbContextOptions options) : base(options)
        { }

        protected AnimalsContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalClassConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureAnimalConfiguration());
        }

    }
}
