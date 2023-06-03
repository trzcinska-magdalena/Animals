using System.ComponentModel.DataAnnotations;

namespace Animals.Models.DTOs
{
    public class AnimalPUT
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        public string AnimalClass { get; set; } = null!;
        [Required]
        public DateTime AdmissionDate { get; set; }
        [Required]
        public int OwnerID { get; set; }
        public ICollection<ProcedurePUT> Procedures { get; set; } = new List<ProcedurePUT>();


    }
}
