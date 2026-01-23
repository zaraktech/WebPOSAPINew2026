using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class ShopNames
    {
        [Key]
        public int ShopNamesId { get; set; }
        [Required]
        public required string ShopName { get; set; }
    }
}
