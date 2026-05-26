using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
[Table("tblBackup")]
public partial class TblBackup
{
    [StringLength(150)]
    [Unicode(false)]
    public string BackUpPath { get; set; } = null!;
}
