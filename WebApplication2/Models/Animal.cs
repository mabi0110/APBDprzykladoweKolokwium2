namespace WebApplication2.Models
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public int OwnerID { get; set; }
        public int AnimalClassID { get; set; }
        public virtual Owner Owner { get; set; } = null!;
        public virtual AnimalClass AnimalClass { get; set; } = null!;
        public virtual ICollection<ProcedureAnimal> ProcedureAnimals { get; set; } = new List<ProcedureAnimal>();
    }
}

