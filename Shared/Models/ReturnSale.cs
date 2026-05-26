using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public partial class ReturnSale
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("RDate")]
    public DateOnly Rdate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string Sizes { get; set; } = null!;

    public int Qty { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Barcode { get; set; } = null!;

    public double Price { get; set; }
}
