using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
[Table("tblBarcode")]
public partial class TblBarcode
{
    [Key]
    public int Barcode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Items { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string? Sizes { get; set; }

    public double SalePrice { get; set; }
}
