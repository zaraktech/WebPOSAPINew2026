using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Customer Name")]
        public required string CustomerName { get; set; } = "-";

        [Range(10, 10, ErrorMessage = "Mobile Number must be 10 character")]
        public string? MobileNo { get; set; }

        //  public virtual List<Sales> Sales { get; set; } = new List<Sales>();
    }
}
