using System.ComponentModel.DataAnnotations;

namespace Animals.Models.DTOs
{
    public class ProcedurePUT
    {
        [Required]
        public int ProcedureID { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
