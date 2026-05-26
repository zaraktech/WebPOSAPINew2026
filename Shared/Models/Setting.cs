using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;


public partial class Setting
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column(TypeName = "numeric(2, 0)")]
    public decimal ReOrder { get; set; }

    [Column(TypeName = "numeric(2, 0)")]
    public decimal MinQty { get; set; }

    [Column(TypeName = "numeric(2, 0)")]
    public decimal? Discount { get; set; }

    public bool EnablePayroll { get; set; }

    public double? PricePercent { get; set; }
}
