using System.ComponentModel.DataAnnotations;

namespace WebPOS.Models
{
    public class Sizes
    {
        public int SizeId { get; set; }

        [Required(ErrorMessage = "Size name is required")]
        public string SizeName { get; set; } = "-";
    }
}
