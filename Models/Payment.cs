using System.ComponentModel.DataAnnotations;

namespace University.API.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Term { get; set; }
        public string? ValidatedBy { get; set; }
        public double TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Program { get; set; }
        public string Link { get; set; }
        public DateTime AddedOn { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
