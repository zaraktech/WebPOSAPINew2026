using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("StockReport")]
public partial class StockReport
{
    [Key]
    public int Id { get; set; }

    public int? Barcode { get; set; }

    [StringLength(75)]
    [Unicode(false)]
    public string? Item { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Sizes { get; set; }

    public int? PurQty { get; set; }

    public int? SaleQty { get; set; }

    public int? SalesReturn { get; set; }

    public int? TransferQty { get; set; }

    public int? OfferSale { get; set; }

    public int? Stock { get; set; }

    public int? Price { get; set; }

    public double? Amount { get; set; }
}
