using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("CustomerMaster")]
public partial class CustomerMaster
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Customer { get; set; } = null!;

    [Column("CAddress")]
    [StringLength(150)]
    [Unicode(false)]
    public string Caddress { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string Telephone { get; set; } = null!;

    [StringLength(13)]
    [Unicode(false)]
    public string MobileNo { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string EmailId { get; set; } = null!;
}
