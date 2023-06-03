using Animals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Animals.Configuration
{
    public class AnimalClassConfiguration : IEntityTypeConfiguration<AnimalClass>
    {
        public void Configure(EntityTypeBuilder<AnimalClass> entity)
        {
            entity.ToTable("Animal_Class");
            entity.HasKey(e => e.ID);

            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();


            entity.HasData(new List<AnimalClass>()
            {
                new AnimalClass
                {
                    ID = 1,
                    Name = "nameclass1"
                },
                new AnimalClass
                {
                    ID = 2,
                    Name = "nameclass2"
                },
                new AnimalClass
                {
                    ID = 3,
                    Name = "nameclass3"
                },
            });
        }
    }
}
