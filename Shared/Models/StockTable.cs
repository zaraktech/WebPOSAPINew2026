using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("StockTable")]
public partial class StockTable
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int ItemId { get; set; }

    public double OpeningQty { get; set; }

    public double PurchaseQty { get; set; }

    public double SalesQty { get; set; }

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }
}
