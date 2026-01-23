using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        public required string SupplierName { get; set; } = "-";
        public string? MobileNo { get; set; }
        [Required]
        public int PaymentDays { get; set; }
    }
}
