using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class ShopNameViewModel
    {
        public int ShopNamesId { get; set; }

        [Required(ErrorMessage = "Shop name is required")]
        public string ShopName { get; set; } = string.Empty;

    }
}
