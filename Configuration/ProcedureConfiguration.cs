using Animals.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Animals.Configuration
{
    public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> entity)
        {
            entity.ToTable("Procedure");
            entity.HasKey(e => e.ID);

            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(100).IsRequired();

            entity.HasData(new List<Procedure>()
            {
                new Procedure
                {
                    ID = 1,
                    Name = "procedure-name",
                    Description = "procedure-desc"
                },
                new Procedure
                {
                    ID = 2,
                    Name = "procedure-name-2",
                    Description = "procedure-desc-2"
                }
            });
        }
    }

}
