using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

[Keyless]
public partial class VStock
{
    public int? Barcode { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string? Sizes { get; set; }

    public int? TotalPurchased { get; set; }

    public int? TotalTransferred { get; set; }

    public int? TotalSales { get; set; }

    public int? TotalOfferSales { get; set; }

    public int? StockQty { get; set; }
}
