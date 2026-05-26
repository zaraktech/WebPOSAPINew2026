using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;


[Table("PriceMaster")]
public partial class PriceMaster
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ITEMID")]
    public int Itemid { get; set; }

    [Column("ITEM")]
    [StringLength(50)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    [Column("BARCODE")]
    [StringLength(20)]
    [Unicode(false)]
    public string Barcode { get; set; } = null!;

    [Column("COSTPRICE")]
    public double Costprice { get; set; }

    [Column("MRP")]
    public double Mrp { get; set; }

    [Column("SELLINGPRICE")]
    public double Sellingprice { get; set; }

    [Column("TAXES")]
    public double Taxes { get; set; }

    [Column("DISCOUNT")]
    public double Discount { get; set; }
}
