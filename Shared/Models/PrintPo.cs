using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
public partial class PrintPo
{
    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [Column("SuppID")]
    public int SuppId { get; set; }

    [Column("POID")]
    public int Poid { get; set; }

    [Column("PDate")]
    public DateOnly Pdate { get; set; }

    [Column("PONO")]
    public int Pono { get; set; }

    public int ItemId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    [StringLength(4)]
    [Unicode(false)]
    public string Unit { get; set; } = null!;

    public DateOnly ReqDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Remarks { get; set; } = null!;

    public double Qty { get; set; }

    public double Price { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Supplier { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Saddress { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    public double Amount { get; set; }

    [Column("MobileNO")]
    [StringLength(13)]
    [Unicode(false)]
    public string MobileNo { get; set; } = null!;

    [Column("EmailID")]
    [StringLength(20)]
    [Unicode(false)]
    public string EmailId { get; set; } = null!;
}
