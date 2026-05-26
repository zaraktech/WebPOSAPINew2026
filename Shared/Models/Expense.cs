using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;


[Table("Expense")]
public partial class Expense
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("EDate")]
    public DateOnly Edate { get; set; }

    [StringLength(75)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    public double Amount { get; set; }
}
