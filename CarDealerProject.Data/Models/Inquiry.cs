using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerProject.Data.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;

        // Foreign Key
        public int CarId { get; set; }

        // ✅ Navigation Property (this fixes your error)
        public Car Car { get; set; } = null!;
    }
}

