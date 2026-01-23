using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class BarcodeStartViewModel
    {
        public int Id { get; set; }

        [Required]
        public int StartingBarcodeNo { get; set; }
    }
}
