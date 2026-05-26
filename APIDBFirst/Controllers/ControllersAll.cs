using APIDBFirst.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace APIDBFirst.Controllers
{
    // ─────────────────────────────────────────────
    // CustomerMaster
    // ─────────────────────────────────────────────
   

    // ─────────────────────────────────────────────
    // Dsname
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class DsnameController : BaseApiController<Dsname>
    {
        public DsnameController(IGenericRepository<Dsname> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // Expense
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : BaseApiController<Expense>
    {
        public ExpenseController(IGenericRepository<Expense> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // ItemMaster
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMasterController : BaseApiController<ItemMaster>
    {
        public ItemMasterController(IGenericRepository<ItemMaster> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // Licence
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class LicenceController : BaseApiController<Licence>
    {
        public LicenceController(IGenericRepository<Licence> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // LoginTable
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class LoginTableController : BaseApiController<LoginTable>
    {
        public LoginTableController(IGenericRepository<LoginTable> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // NewCustomerMaster
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class NewCustomerMasterController : BaseApiController<NewCustomerMaster>
    {
        public NewCustomerMasterController(IGenericRepository<NewCustomerMaster> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // OfferSale
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class OfferSaleController : BaseApiController<OfferSale>
    {
        public OfferSaleController(IGenericRepository<OfferSale> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // Option
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : BaseApiController<Option>
    {
        public OptionController(IGenericRepository<Option> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // PriceMaster
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class PriceMasterController : BaseApiController<PriceMaster>
    {
        public PriceMasterController(IGenericRepository<PriceMaster> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // Purchase
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : BaseApiController<Purchase>
    {
        public PurchaseController(IGenericRepository<Purchase> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // ReturnSale
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnSaleController : BaseApiController<ReturnSale>
    {
        public ReturnSaleController(IGenericRepository<ReturnSale> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // Sale
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : BaseApiController<Sale>
    {
        public SaleController(IGenericRepository<Sale> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // SalesBill
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class SalesBillController : BaseApiController<SalesBill>
    {
        public SalesBillController(IGenericRepository<SalesBill> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // SalesReturn
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReturnController : BaseApiController<SalesReturn>
    {
        public SalesReturnController(IGenericRepository<SalesReturn> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // Setting
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : BaseApiController<Setting>
    {
        public SettingController(IGenericRepository<Setting> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // SizeMaster
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class SizeMasterController : BaseApiController<SizeMaster>
    {
        public SizeMasterController(IGenericRepository<SizeMaster> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // StockReport
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class StockReportController : BaseApiController<StockReport>
    {
        public StockReportController(IGenericRepository<StockReport> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // StockTable
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class StockTableController : BaseApiController<StockTable>
    {
        public StockTableController(IGenericRepository<StockTable> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // StoreDetail
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class StoreDetailController : BaseApiController<StoreDetail>
    {
        public StoreDetailController(IGenericRepository<StoreDetail> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // SupplierMaster
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierMasterController : BaseApiController<SupplierMaster>
    {
        public SupplierMasterController(IGenericRepository<SupplierMaster> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // TblBackup
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class TblBackupController : BaseApiController<TblBackup>
    {
        public TblBackupController(IGenericRepository<TblBackup> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // TblBarcode
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class TblBarcodeController : BaseApiController<TblBarcode>
    {
        public TblBarcodeController(IGenericRepository<TblBarcode> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // TblFinYear
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class TblFinYearController : BaseApiController<TblFinYear>
    {
        public TblFinYearController(IGenericRepository<TblFinYear> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // TblGsttaxReport
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class TblGsttaxReportController : BaseApiController<TblGsttaxReport>
    {
        public TblGsttaxReportController(IGenericRepository<TblGsttaxReport> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // TblReward
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class TblRewardController : BaseApiController<TblReward>
    {
        public TblRewardController(IGenericRepository<TblReward> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // TblStartNo
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class TblStartNoController : BaseApiController<TblStartNo>
    {
        public TblStartNoController(IGenericRepository<TblStartNo> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // TblStore
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class TblStoreController : BaseApiController<TblStore>
    {
        public TblStoreController(IGenericRepository<TblStore> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // TblTaxReport
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class TblTaxReportController : BaseApiController<TblTaxReport>
    {
        public TblTaxReportController(IGenericRepository<TblTaxReport> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // TransferPurchase
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class TransferPurchaseController : BaseApiController<TransferPurchase>
    {
        public TransferPurchaseController(IGenericRepository<TransferPurchase> repository)
            : base(repository) { }
    }

    // ─────────────────────────────────────────────
    // Uommaster
    // ─────────────────────────────────────────────
    [Route("api/[controller]")]
    [ApiController]
    public class UommasterController : BaseApiController<Uommaster>
    {
        public UommasterController(IGenericRepository<Uommaster> repository)
            : base(repository) { }
    }
}
