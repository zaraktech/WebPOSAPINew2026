using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("LoginTable")]
public partial class LoginTable
{
    [Key]
    [Column("LId")]
    public int Lid { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string Password { get; set; } = null!;
}
