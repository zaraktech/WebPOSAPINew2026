using System.ComponentModel.DataAnnotations;

namespace WebPOS.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Item name is required")]
        [StringLength(100, ErrorMessage = "Item name cannot exceed 100 characters")]
        public string ProductName { get; set; } = string.Empty;


    }
}
