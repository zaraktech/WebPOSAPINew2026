using System.ComponentModel.DataAnnotations;

namespace WebPOS.Models
{
    public class Customer
    {
        public int Id { get; set; }

        // [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, ErrorMessage = "Customer name cannot exceed 100 characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(10, ErrorMessage = "Mobile number cannot exceed 10 characters")]
        public string MobileNo { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
