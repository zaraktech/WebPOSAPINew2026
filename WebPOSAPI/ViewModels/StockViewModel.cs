using Microsoft.EntityFrameworkCore;

namespace WebAPI.ViewModels
{
    [Keyless]
    public class StockViewModel
    {
        public string ShopName { get; set; } = string.Empty;

        public int Barcode { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;

        public int PurchaseQty { get; set; }
        public int SalesQty { get; set; }

        public int BalanceQty => PurchaseQty - SalesQty;

        public decimal SalePrice { get; set; }
        public decimal StockValue => BalanceQty * SalePrice;
    }
}
