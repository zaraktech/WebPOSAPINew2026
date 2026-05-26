using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
public partial class Option
{
    [Column("optPayroll")]
    public bool OptPayroll { get; set; }

    [Column("optPurchaseOrder")]
    public bool OptPurchaseOrder { get; set; }

    [Column("optPurchaseRetrun")]
    public bool OptPurchaseRetrun { get; set; }

    [Column("optQuotation")]
    public bool OptQuotation { get; set; }

    [Column("optCustomerMaster")]
    public bool OptCustomerMaster { get; set; }

    [Column("optPOCancel")]
    public bool OptPocancel { get; set; }

    [Column("optDailyExpense")]
    public bool OptDailyExpense { get; set; }

    [Column("optSupplierMaster")]
    public bool OptSupplierMaster { get; set; }
}
