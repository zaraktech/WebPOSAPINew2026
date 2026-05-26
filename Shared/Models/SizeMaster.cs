using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("SizeMaster")]
public partial class SizeMaster
{
    [Key]
    public int SizId { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Sizes { get; set; } = null!;
}
