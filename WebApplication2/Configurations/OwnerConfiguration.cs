using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(100);

            builder.HasData(new List<Owner>
            {
                new Owner {
                    ID = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new Owner {
                    ID = 2,
                    FirstName = "Anna",
                    LastName = "Nowak"
                }
            });
        }
    }
}
