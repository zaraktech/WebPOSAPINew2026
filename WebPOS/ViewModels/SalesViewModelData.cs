namespace WebPOS.ViewModels
{
    public class SalesViewModelData
    {
        public int Id { get; set; }
        public int BillNo { get; set; }

        public int Barcode { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string MobileNo { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;

        public int RewardPoints { get; set; }

        public double GSTPercent { get; set; }
        public double DiscountPercent { get; set; }

        public double TotalAmount { get; set; }
        public double TotalAmountGST { get; set; }



        public int SaleItemId { get; set; }


        public int SaleId { get; set; }


        public int ProductId { get; set; }

        public string Product { get; set; }

        public int SizesId { get; set; }

        public String Sizes { get; set; }


        public int Qty { get; set; }

        public decimal SalePrice { get; set; }

        public decimal Discount { get; set; }

        public decimal AmtAfterDiscount { get; set; }

        public decimal Cgst { get; set; }

        public decimal Sgst { get; set; }

        public decimal Igst { get; set; }
        // List of sale items
    }
}
