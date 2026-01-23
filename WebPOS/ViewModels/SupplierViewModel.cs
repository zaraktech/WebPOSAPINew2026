using System.ComponentModel.DataAnnotations;

namespace WebPOS.ViewModels
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Supplier Name is required")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Mobile No is required")]
        [Phone(ErrorMessage = "Enter a valid mobile number")]
        public string MobileNo { get; set; }
    }
}
