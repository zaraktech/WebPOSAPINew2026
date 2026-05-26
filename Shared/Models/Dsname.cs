using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
[Table("DSName")]
public partial class Dsname
{
    [StringLength(50)]
    [Unicode(false)]
    public string InstanceName { get; set; } = null!;
}
