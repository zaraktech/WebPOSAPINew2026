namespace WebPOS.Models
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string InvoiceNo { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string? BarcodeText { get; set; }
        public int Barcode { get; set; }
        public int Qty { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public int? ShopNamesId { get; set; }
        public string ShopName { get; set; }

        public decimal Amount
        {
            get
            {
                return Qty * CostPrice;
            }
        }
    }
}
