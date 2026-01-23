using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class SupplierViewModel
    {

        public int SupplierId { get; set; }
        [Required]
        public required string SupplierName { get; set; } = "-";
        public string? MobileNo { get; set; }
        [Required]
        public int PaymentDays { get; set; }
    }
}
