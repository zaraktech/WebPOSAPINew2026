using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Item name is required")]
        [StringLength(100, ErrorMessage = "Item name cannot exceed 100 characters")]
        public string ProductName { get; set; } = string.Empty;
    }
}
