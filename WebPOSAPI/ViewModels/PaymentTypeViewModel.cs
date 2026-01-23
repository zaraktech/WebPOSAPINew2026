using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class PaymentTypeViewModel
    {

        public int PaymentId { get; set; }

        [Required]
        public string PaymentType { get; set; }
    }
}
