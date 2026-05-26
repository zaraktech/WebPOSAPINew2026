namespace WebPOS.ViewModels
{
    public class SaleItemViewModel
    {
        public string BarcodeText { get; set; }
        public int Barcode { get; set; }


        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int Qty { get; set; }
        public decimal SalePrice { get; set; }
        public decimal SaleAmount { get; set; }

        public decimal TotalAmount => Qty * SalePrice;
        public int? ShopnameId { get; set; }
        public String ShopName { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal Amount { get; set; }

        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }
    }
}
