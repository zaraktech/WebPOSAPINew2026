using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;


[Table("SalesBill")]
public partial class SalesBill
{
    [Key]
    [Column("SaleID")]
    public int SaleId { get; set; }
    public DateOnly SaleDate { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    public double SellingPrice { get; set; }

    public double Amount { get; set; }

    public int Qty { get; set; }

    public double ReceivedAmt { get; set; }

    public double BillAmount { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string BillText { get; set; } = null!;

    public double? NetAmount { get; set; }

    public double? DiscountAmt { get; set; }

    [Column("EDiscountAmt")]
    public double? EdiscountAmt { get; set; }

    [Column("GSTPERCENT")]
    public double? Gstpercent { get; set; }

    [Column("CGSTAMT")]
    public double? Cgstamt { get; set; }

    [Column("IGSTAMT")]
    public double? Igstamt { get; set; }

    [Column("AMTWGST")]
    public double? Amtwgst { get; set; }

    [Column("AMTWOGST")]
    public double? Amtwogst { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? FinYear { get; set; }
}
