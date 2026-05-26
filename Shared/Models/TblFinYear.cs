using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
[Table("tblFinYear")]
public partial class TblFinYear
{
    [StringLength(50)]
    [Unicode(false)]
    public string? FinYear { get; set; }
}
