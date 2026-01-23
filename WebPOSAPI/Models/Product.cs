using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public required string ProductName { get; set; } = "-";
        //   public virtual List<SaleItems> SaleItems { get; set; } = new List<SaleItems>();
    }
}
