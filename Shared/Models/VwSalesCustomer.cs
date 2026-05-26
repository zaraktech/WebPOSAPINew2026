using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
public partial class VwSalesCustomer
{
    public int BillNo { get; set; }

    public DateOnly SaleDate { get; set; }

    [Column("ItemID")]
    public int ItemId { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Item { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string? Sizes { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Unit { get; set; } = null!;

    public double SellingPrice { get; set; }

    public double Amount { get; set; }

    public double Taxes { get; set; }

    public double TaxAmount { get; set; }

    public double DiscountAmt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PayType { get; set; }

    public double Qty { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InvoiceText { get; set; }

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
