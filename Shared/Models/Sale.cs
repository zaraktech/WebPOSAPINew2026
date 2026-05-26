using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;


public partial class Sale
{
    [Key]
    [Column("SaleID")]
    public int SaleId { get; set; }

    public int BillNo { get; set; }

    public DateOnly SaleDate { get; set; }

    [Column("ItemID")]
    public int ItemId { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string? Sizes { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    public double SellingPrice { get; set; }

    public double Amount { get; set; }

    public double Discount { get; set; }

    public double DiscountAmt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PayType { get; set; }

    public int Qty { get; set; }

    public double ReceivedAmt { get; set; }

    public double BillAmount { get; set; }

    public double DiffAmt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Customer { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? MobileNo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string BillText { get; set; } = null!;

    public double? NetAmount { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Barcode { get; set; } = null!;

    [Column("EDiscountAmt")]
    public double? EdiscountAmt { get; set; }

    public double Rewards { get; set; }

    [Column("GSTPercent")]
    public double? Gstpercent { get; set; }

    [Column("IGSTAmt")]
    public double? Igstamt { get; set; }

    [Column("CGSTAmt")]
    public double? Cgstamt { get; set; }

    [Column("AmtwGST")]
    public double? AmtwGst { get; set; }

    [Column("AmtwoGST")]
    public double? AmtwoGst { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FinYear { get; set; }
}
