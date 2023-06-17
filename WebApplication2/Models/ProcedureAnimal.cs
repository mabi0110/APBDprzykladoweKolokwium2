namespace WebApplication2.Models
{
    public class ProcedureAnimal
    {
        public int ProcedureID { get; set; }
        public int AnimalID { get; set; }
        public DateTime Date { get; set; }
        public virtual Procedure Procedure { get; set; } = null!;
        public virtual Animal Animal { get; set; } = null!;
    }
}
