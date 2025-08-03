using System.ComponentModel.DataAnnotations;

namespace CarDealerProject.Models
{
    public class InquiryViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;

        [Required]
        public int CarId { get; set; }  // ✅ Add this so the form works
    }
}
