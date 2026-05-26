using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Keyless]
[Table("tblStartNos")]
public partial class TblStartNo
{
    public int StartBarcode { get; set; }

    public int StartBillNo { get; set; }

    public int? CostPercent { get; set; }
}
