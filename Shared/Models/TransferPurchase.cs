using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("TransferPurchase")]
public partial class TransferPurchase
{
    [Key]
    public int Trid { get; set; }

    [Column("INVNo")]
    [StringLength(10)]
    [Unicode(false)]
    public string Invno { get; set; } = null!;

    public DateOnly PurDate { get; set; }

    [Column("ItemID")]
    public int ItemId { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string? Sizes { get; set; }

    public int Qty { get; set; }

    public double SalePrice { get; set; }

    public double CostPrice { get; set; }

    public double TotalAmount { get; set; }

    public int? Discount { get; set; }

    public int? Barcode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TranferFrom { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TranferTo { get; set; }

    public DateOnly? TrfDate { get; set; }

    public int? TrfNo { get; set; }
}
