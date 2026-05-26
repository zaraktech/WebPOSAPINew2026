using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

[Keyless]
public partial class VwStock
{
    public int ItemId { get; set; }

    public double OpeningQty { get; set; }

    public double PurchaseQty { get; set; }

    public double SalesQty { get; set; }

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string Sizes { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Unit { get; set; } = null!;
}
