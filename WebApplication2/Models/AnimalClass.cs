namespace WebApplication2.Models
{
    public class AnimalClass
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
