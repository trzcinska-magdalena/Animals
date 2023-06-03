namespace Animals.Models.DTOs
{
    public class OwnerGET
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
