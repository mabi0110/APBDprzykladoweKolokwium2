using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace WebApplication2.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");

            builder.HasKey(e => e.ID);
            builder.Property(e => e.Name).HasMaxLength(100);

            builder.HasOne(e => e.Owner)
                .WithMany(e => e.Animals)
                .HasForeignKey(e => e.OwnerID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.AnimalClass)
                .WithMany(e => e.Animals)
                .HasForeignKey(e => e.AnimalClassID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Animal>()
            {
                new Animal
                {
                    ID = 1,
                    Name = "AnimalName",
                    AdmissionDate = DateTime.Parse("2023-05-13"),
                    OwnerID = 1,
                    AnimalClassID = 1
                }
            });

        }
    }
}

