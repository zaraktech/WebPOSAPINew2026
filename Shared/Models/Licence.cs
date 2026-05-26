using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("Licence")]
public partial class Licence
{
    [Key]
    public int SetId { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string LicenseType { get; set; } = null!;

    public int Days { get; set; }

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }
}
