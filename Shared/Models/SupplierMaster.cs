using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;


[Table("SupplierMaster")]
public partial class SupplierMaster
{
    [Key]
    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Supplier { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Saddress { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string Telephone { get; set; } = null!;

    [Column("MobileNO")]
    [StringLength(13)]
    [Unicode(false)]
    public string MobileNo { get; set; } = null!;

    [Column("EmailID")]
    [StringLength(20)]
    [Unicode(false)]
    public string EmailId { get; set; } = null!;
}
