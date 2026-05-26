using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;


[Table("SalesReturn")]
public partial class SalesReturn
{
    [Key]
    [Column("SRID")]
    public int Srid { get; set; }

    [Column("SRDate")]
    public DateOnly Srdate { get; set; }

    [Column("SaleID")]
    public int SaleId { get; set; }

    public int BillNo { get; set; }

    public DateOnly SaleDate { get; set; }

    [Column("ItemID")]
    public int ItemId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    [Column(TypeName = "numeric(12, 0)")]
    public decimal Qty { get; set; }

    [StringLength(4)]
    [Unicode(false)]
    public string Unit { get; set; } = null!;

    [Column("MRP")]
    public double Mrp { get; set; }

    public double SellingPrice { get; set; }

    public double Taxes { get; set; }

    public double Discount { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Paytype { get; set; } = null!;

    [Column("CDNumber")]
    [StringLength(16)]
    [Unicode(false)]
    public string Cdnumber { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Barcode { get; set; } = null!;
}
