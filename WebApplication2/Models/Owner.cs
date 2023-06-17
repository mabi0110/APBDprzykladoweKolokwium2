namespace WebApplication2.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    }
}
