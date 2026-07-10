using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
[Table("tblStore")]
public partial class TblStore
{
    [Key]
    [Column("StoreID")]
    public int StoreID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Store { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string MobileNo { get; set; } = null!;

    [Column("GSTNo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Gstno { get; set; }

    [Column("GSTPERCENT")]
    public double? Gstpercent { get; set; }
}
