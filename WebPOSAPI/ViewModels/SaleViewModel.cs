namespace WebAPI.ViewModels
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public int BillNo { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; } = "-";
        public int PaymentId { get; set; }

        public string MobileNo { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public int RewardPoints { get; set; }
        public double GSTPercent { get; set; }


        public List<SaleItemViewModel> SaleItems { get; set; } = new();
    }
}
