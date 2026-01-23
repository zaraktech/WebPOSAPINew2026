namespace WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace WebPOSAPI.Models
    {
        public class SaleItems
        {


            [Key]
            public int SaleItemId { get; set; }

            public int Barcode { get; set; }

            [ForeignKey(nameof(Sale))]
            public int SaleId { get; set; }
            public virtual Sales Sale { get; set; }


            [ForeignKey(nameof(Product))]
            public int ProductId { get; set; }
            public virtual Product Product { get; set; }

            [ForeignKey(nameof(SizeId))]
            public int SizeId { get; set; }
            public virtual Sizes Sizes { get; set; }


            [ForeignKey(nameof(ShopNamesId))]
            public int? ShopNamesId { get; set; }

            public virtual ShopNames ShopNames { get; set; }



            public int Qty { get; set; }
            public decimal SalePrice { get; set; }
            public decimal Discount { get; set; }
            public decimal DiscountAmount { get; set; }
            public decimal AmountAfterDiscount { get; set; }

            public decimal CGST { get; set; }
            public decimal SGST { get; set; }
            public decimal IGST { get; set; }

            // Calculated properties (if using computed columns)
            public decimal LineTotal => Qty * SalePrice;
            public decimal NetAmount => LineTotal - DiscountAmount;
        }
    }

}
