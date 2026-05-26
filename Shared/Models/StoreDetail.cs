using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
public partial class StoreDetail
{
    [StringLength(50)]
    [Unicode(false)]
    public string StoreName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string StoreAddress { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string? ZipCode { get; set; }

    [StringLength(13)]
    [Unicode(false)]
    public string? MobileNo { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("TelephoneNO")]
    [StringLength(15)]
    [Unicode(false)]
    public string? TelephoneNo { get; set; }

    [Column("VATNo")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Vatno { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LogoPath { get; set; }
}
