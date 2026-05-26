using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.WebPOSAPI.Models;





namespace WebAPI.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }


        public int BillNo { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public int PaymentTypeId { get; set; }
        public Customer Customer { get; set; }

        public int RewardPoints { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;




        // Sale-level calculations


        // Tax and discount percentages
        public decimal GSTPercent { get; set; }


        // Navigation property
        public virtual List<SaleItems> SaleItems { get; set; } = new List<SaleItems>();
    }
}
