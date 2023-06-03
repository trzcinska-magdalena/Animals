using Animals.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Animals.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> entity)
        {
            entity.ToTable("Owner");
            entity.HasKey(e => e.ID);

            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
          
            entity.HasData(new List<Owner>()
            {
                new Owner
                {
                    ID = 1,
                    FirstName = "Anna",
                    LastName = "Kowal"
                },
                new Owner
                {
                    ID = 2,
                    FirstName = "Michał",
                    LastName = "Kowalczyk"
                }
            });
        }
    }
}
