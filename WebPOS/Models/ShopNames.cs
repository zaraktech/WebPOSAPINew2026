using System.ComponentModel.DataAnnotations;

namespace WebPOS.Models
{
    public class ShopNames
    {
        public int ShopNamesId { get; set; }

        [Required(ErrorMessage = "Shop name is required")]
        public string ShopName { get; set; } = string.Empty;

    }
}
