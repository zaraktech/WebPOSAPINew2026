namespace WebAPI.ViewModels
{
    public class SaleItemViewModel
    {
        public int Barcode { get; set; }
        public int SaleItemId { get; set; }
        public int SaleId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }  // MUST BE string

        public int SizeId { get; set; }
        public string SizeName { get; set; }     // MUST BE string

        public int Qty { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal Amount { get; set; }

        public int ShopNameId { get; set; }
        public string ShopNameName { get; set; } = string.Empty;
    }

}
