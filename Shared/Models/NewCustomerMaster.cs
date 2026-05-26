using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("NewCustomerMaster")]
public partial class NewCustomerMaster
{
    [Key]
    [Column("CustID")]
    public int CustId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Customer { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string? MobileNo { get; set; }
}
