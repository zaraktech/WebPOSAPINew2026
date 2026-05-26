using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
public partial class VwSupplierPurchase
{
    [StringLength(100)]
    [Unicode(false)]
    public string Supplier { get; set; } = null!;

    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [Column("GRNNO")]
    [StringLength(10)]
    [Unicode(false)]
    public string Grnno { get; set; } = null!;

    public DateOnly PurDate { get; set; }
}
