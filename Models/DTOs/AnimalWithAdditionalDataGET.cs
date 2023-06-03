namespace Animals.Models.DTOs
{
    public class AnimalWithAdditionalDataGET
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string AnimalClass { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public OwnerGET Owners { get; set; } = null!;
        public ICollection<ProcedureGET> Procedures { get; set; } = new List<ProcedureGET>();
    }
}
