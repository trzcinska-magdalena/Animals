using Animals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Animals.Configuration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> entity)
        {
            entity.ToTable("Animal");
            entity.HasKey(e => e.ID);

            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.AdmissionDate).IsRequired();


            entity.HasOne(e => e.Owner)
            .WithMany(e => e.Animals)
            .HasForeignKey(e => e.OwnerID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.AnimalClass)
            .WithMany(e => e.Animals)
            .HasForeignKey(e => e.AnimalClassID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(new List<Animal>()
            {
                new Animal
                {
                    ID = 1,
                    Name = "nameAnimal1",
                    AdmissionDate = new DateTime(2020,03,03),
                    OwnerID = 1,
                    AnimalClassID = 3,
                },
                new Animal
                {
                    ID = 2,
                    Name = "nameAnimal2",
                    AdmissionDate = new DateTime(2020,04,03),
                    OwnerID = 2,
                    AnimalClassID = 2,
                },
                new Animal
                {
                    ID = 3,
                    Name = "nameAnimal3",
                    AdmissionDate = new DateTime(2022,10,30),
                    OwnerID = 2,
                    AnimalClassID = 2,
                },
            });
        }

    }
}
