using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;


[Table("SupplierMaster")]
public partial class SupplierMaster
{
    [Key]
    public int SupplierId { get; set; }

    [Required(ErrorMessage = "Supplier name is required")]
    [StringLength(100, ErrorMessage = "Supplier name cannot exceed 100 characters")]
    public string SupplierName { get; set; }

    [Required(ErrorMessage = "Mobile number is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    [StringLength(10, ErrorMessage = "Mobile number cannot exceed 10 characters")]
    public string MobileNo { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
