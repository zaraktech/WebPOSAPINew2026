using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class BarcodeStart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StartingBarcodeNo { get; set; } = 10000;
    }
}
