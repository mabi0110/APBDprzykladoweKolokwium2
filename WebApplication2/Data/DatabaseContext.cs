using Microsoft.EntityFrameworkCore;
using WebApplication2.Configurations;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<AnimalClass> AnimalClasses { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<ProcedureAnimal> ProcedureAnimals { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalClassConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureAnimalConfiguration());
        }
    }
}

