namespace WebPOS.ViewModels
{
    public class StockReportViewModel
    {
        public string ShopName { get; set; } = string.Empty;
        public int Barcode { get; set; } = 0;
        public string ProductName { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;

        public decimal PurchaseQty { get; set; }
        public decimal SalesQty { get; set; }

        public decimal BalanceQty => PurchaseQty - SalesQty;

        public decimal SalePrice { get; set; }

        // Stock value based on available balance
        public decimal StockValue => BalanceQty * SalePrice;
    }

}
