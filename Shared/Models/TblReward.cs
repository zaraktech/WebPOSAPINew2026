using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("tblRewards")]
public partial class TblReward
{
    [Key]
    [Column("IDs")]
    public int Ids { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Customer { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string MobileNo { get; set; } = null!;

    public double Rewards { get; set; }

    [Column("BDate")]
    public DateOnly Bdate { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? IsRedeem { get; set; }
}
