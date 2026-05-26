using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("tblGSTTaxReport")]
public partial class TblGsttaxReport
{
    [Key]
    public int Id { get; set; }

    [Column("FDate")]
    public DateOnly Fdate { get; set; }

    [Column("TDate")]
    public DateOnly Tdate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string MonthYear { get; set; } = null!;

    public DateOnly SaleDate { get; set; }

    [StringLength(75)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    public double Amount { get; set; }

    public int? BillNo { get; set; }

    [Column("IGST")]
    public double? Igst { get; set; }

    [Column("CGST")]
    public double? Cgst { get; set; }

    [Column("GST")]
    public double? Gst { get; set; }

    [Column("AmtwGST")]
    public double? AmtwGst { get; set; }

    public double? Amtwogst { get; set; }
}
