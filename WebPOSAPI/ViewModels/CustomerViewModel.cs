using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string MobileNo { get; set; }
    }
}
