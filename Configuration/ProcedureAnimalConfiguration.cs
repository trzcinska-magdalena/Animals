using Animals.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Animals.Configuration
{
    public class ProcedureAnimalConfiguration : IEntityTypeConfiguration<ProcedureAnimal>
    {
        public void Configure(EntityTypeBuilder<ProcedureAnimal> entity)
        {
            entity.ToTable("Procedure_Animal");
            entity.HasKey(e => new {e.ProcedureID, e.AnimalID});

            entity.Property(e => e.Date).IsRequired();


            entity.HasOne(e => e.Procedure)
            .WithMany(e => e.ProcedureAnimals)
            .HasForeignKey(e => e.ProcedureID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Animal)
            .WithMany(e => e.ProcedureAnimals)
            .HasForeignKey(e => e.AnimalID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(new List<ProcedureAnimal>()
            {
                new ProcedureAnimal
                {
                    ProcedureID = 1,
                    AnimalID = 1,
                    Date = new DateTime(2020,03,03)
                },
                new ProcedureAnimal
                {
                    ProcedureID = 2,
                    AnimalID = 2,
                    Date = new DateTime(2020,05,03)
                },
                new ProcedureAnimal
                {
                    ProcedureID = 1,
                    AnimalID = 3,
                    Date = new DateTime(2018,10,03)
                },
            });
        }
    }

}
