using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class PaymentTypes
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public string PaymentType { get; set; }
    }
}
