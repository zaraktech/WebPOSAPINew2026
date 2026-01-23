using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Sizes
    {
        [Key]
        public int SizeId { get; set; }
        [Required]
        public required string SizeName { get; set; } = "-";
        //  public virtual List<SaleItems> SaleItems { get; set; } = new List<SaleItems>();
    }
}
