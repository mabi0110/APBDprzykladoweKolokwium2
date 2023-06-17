using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Configurations
{
    public class ProcedureAnimalConfiguration : IEntityTypeConfiguration<ProcedureAnimal>
    {
        public void Configure(EntityTypeBuilder<ProcedureAnimal> builder)
        {
            builder.ToTable("Procedure_Animal");

            builder.HasKey(e => new { e.ProcedureID, e.AnimalID, e.Date });

            builder.HasOne(e => e.Animal)
                .WithMany(e => e.ProcedureAnimals)
                .HasForeignKey(e => e.AnimalID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Procedure)
               .WithMany(e => e.ProcedureAnimals)
               .HasForeignKey(e => e.ProcedureID)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<ProcedureAnimal>()
            {
                new ProcedureAnimal
                {
                    ProcedureID = 1,
                    AnimalID = 1,
                    Date = DateTime.Parse("2023-05-14")
                },
                new ProcedureAnimal
                {
                    ProcedureID = 2,
                    AnimalID = 1,
                    Date = DateTime.Parse("2023-05-15")
                }
            });
        }
    }
}


