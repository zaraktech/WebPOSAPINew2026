using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Purchases
    {
        [Key]
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string InvoiceNo { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(Sizes))]
        public int SizeId { get; set; }
        public Sizes Sizes { get; set; }

        public string? BarcodeText { get; set; }
        public int Barcode { get; set; }
        public int Qty { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }

        [ForeignKey(nameof(ShopName))]
        public int ShopNamesId { get; set; }
        public ShopNames ShopName { get; set; } // This looks like a value, not a foreign key entity
    }

}
