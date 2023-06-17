namespace WebApplication2.Models.DTOs
{
    public class AnimalDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string AnimalClass { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public AnimalOwnerDTO Owner { get; set; } = null!;
        public ICollection<AnimalProcedureDTO> Procedures { get; set; } = new List<AnimalProcedureDTO>();
    }
}
