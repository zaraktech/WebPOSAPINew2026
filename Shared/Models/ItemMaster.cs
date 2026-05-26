using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("ItemMaster")]
public partial class ItemMaster
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    public double DisPercent { get; set; }

    public int? ReOrder { get; set; }
}
