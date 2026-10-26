using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("Purchase")]
public partial class Purchase
{
    [Key]
    [Column("PURID")]
    public int Purid { get; set; }

    [Column("INVNo")]
    [StringLength(10)]
    [Unicode(false)]
    public string Invno { get; set; } = null!;

    public DateOnly PurDate { get; set; }

    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [Column("ItemID")]
    public int ItemId { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    public int SizeId { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string? Sizes { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Unit { get; set; } = null!;

    public int Qty { get; set; }

    public double SalePrice { get; set; }

    public double CostPrice { get; set; }

    public double TotalAmount { get; set; }

    public int? Discount { get; set; }

    public int? Barcode { get; set; }
}
