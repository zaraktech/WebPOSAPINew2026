using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("OfferSale")]
public partial class OfferSale
{
    [Key]
    [Column("OID")]
    public int Oid { get; set; }

    public int OldBarcode { get; set; }

    public int Barcode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string? Sizes { get; set; }

    public int Qty { get; set; }

    public double SalePrice { get; set; }

    public double Amount { get; set; }
}
