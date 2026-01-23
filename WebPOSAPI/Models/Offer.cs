namespace WebAPI.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public int Barcode { get; set; }

        public decimal SalePrice { get; set; }
        public decimal OfferPrice { get; set; }



        public bool IsActive { get; set; }
    }
}
