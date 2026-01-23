using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class SizeViewModel
    {

        public int SizeId { get; set; }

        [Required(ErrorMessage = "Size name is required")]
        public string SizeName { get; set; } = "-";

    }
}
