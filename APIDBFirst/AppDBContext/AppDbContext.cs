using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace APIDBFirst.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }

    public virtual DbSet<Dsname> Dsnames { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ItemMaster> ItemMasters { get; set; }

    public virtual DbSet<Licence> Licences { get; set; }

    public virtual DbSet<LoginTable> LoginTables { get; set; }

    public virtual DbSet<NewCustomerMaster> NewCustomerMasters { get; set; }

    public virtual DbSet<OfferSale> OfferSales { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<PriceMaster> PriceMasters { get; set; }

    public virtual DbSet<PrintPo> PrintPos { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<ReturnSale> ReturnSales { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesBill> SalesBills { get; set; }

    public virtual DbSet<SalesReturn> SalesReturns { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SizeMaster> SizeMasters { get; set; }

    public virtual DbSet<StockReport> StockReports { get; set; }

    public virtual DbSet<StockTable> StockTables { get; set; }

    public virtual DbSet<StoreDetail> StoreDetails { get; set; }

    public virtual DbSet<SupplierMaster> SupplierMasters { get; set; }

    public virtual DbSet<TblBackup> TblBackups { get; set; }

    public virtual DbSet<TblBarcode> TblBarcodes { get; set; }

    public virtual DbSet<TblFinYear> TblFinYears { get; set; }

    public virtual DbSet<TblGsttaxReport> TblGsttaxReports { get; set; }

    public virtual DbSet<TblReward> TblRewards { get; set; }

    public virtual DbSet<TblStartNo> TblStartNos { get; set; }

    public virtual DbSet<TblStore> TblStores { get; set; }

    public virtual DbSet<TblTaxReport> TblTaxReports { get; set; }

    public virtual DbSet<TransferPurchase> TransferPurchases { get; set; }

    public virtual DbSet<Uommaster> Uommasters { get; set; }

    public virtual DbSet<VStock> VStocks { get; set; }

    public virtual DbSet<VwPurchase> VwPurchases { get; set; }

    public virtual DbSet<VwSalesCustomer> VwSalesCustomers { get; set; }

    public virtual DbSet<VwStock> VwStocks { get; set; }

    public virtual DbSet<VwSupplierPurchase> VwSupplierPurchases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DBINVEN;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerMaster>(entity =>
        {
            entity.Property(e => e.EmailId).HasDefaultValue("-", "DF_CustomerMaster_EmailId");
            entity.Property(e => e.MobileNo).HasDefaultValue("-", "DF_CustomerMaster_MobileNo");
            entity.Property(e => e.Telephone).HasDefaultValue("-", "DF_CustomerMaster_Telephone");
        });

        modelBuilder.Entity<Dsname>(entity =>
        {
            entity.Property(e => e.InstanceName).HasDefaultValue("-", "DF_DSName_InstanceName");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ItemMaster>(entity =>
        {
            entity.Property(e => e.ReOrder).HasDefaultValue(0, "DF_ItemMaster_ReOrder");
        });

        modelBuilder.Entity<Licence>(entity =>
        {
            entity.HasKey(e => e.SetId).HasName("PK_Settings");
        });

        modelBuilder.Entity<NewCustomerMaster>(entity =>
        {
            entity.Property(e => e.MobileNo).HasDefaultValue("-", "DF_NewCustomerMaster_MobileNo");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.Property(e => e.OptCustomerMaster).HasDefaultValue(true, "DF_Options_optCustomerMaster");
            entity.Property(e => e.OptDailyExpense).HasDefaultValue(true, "DF_Options_optDailyExpense");
            entity.Property(e => e.OptPayroll).HasDefaultValue(true, "DF_Table_1_Payroll");
            entity.Property(e => e.OptPocancel).HasDefaultValue(true, "DF_Options_optPOCancel");
            entity.Property(e => e.OptPurchaseOrder).HasDefaultValue(true, "DF_Options_optPurchaseOrder");
            entity.Property(e => e.OptPurchaseRetrun).HasDefaultValue(true, "DF_Options_optPurchaseRetrun");
            entity.Property(e => e.OptQuotation).HasDefaultValue(true, "DF_Options_optQuotation");
            entity.Property(e => e.OptSupplierMaster).HasDefaultValue(true, "DF_Options_optSupplierMaster");
        });

        modelBuilder.Entity<PriceMaster>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PrintPo>(entity =>
        {
            entity.ToView("PrintPO");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.Property(e => e.Discount).HasDefaultValue(0, "DF_Purchase_Discount");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.Property(e => e.Barcode).HasDefaultValue("-", "DF__Sales__Barcode__5C8CB268");
            entity.Property(e => e.BillText).HasDefaultValue("-", "DF__Sales__BillText__5AA469F6");
            entity.Property(e => e.Customer).HasDefaultValue("-", "DF_Sales_Customer");
            entity.Property(e => e.EdiscountAmt).HasDefaultValue(0.0, "DF_Sales_EDiscountAmt");
            entity.Property(e => e.MobileNo).HasDefaultValue("-", "DF_Sales_MobileNo");
            entity.Property(e => e.NetAmount).HasDefaultValue(0.0, "DF__Sales__NetAmount__5B988E2F");
            entity.Property(e => e.PayType).HasDefaultValue("Cash", "DF__Sales__PayType__71F1E3A2");
            entity.Property(e => e.SaleId).ValueGeneratedOnAdd();
            entity.Property(e => e.Sizes).HasDefaultValue("-", "DF_Sales_Sizes");
        });

        modelBuilder.Entity<SalesBill>(entity =>
        {
            entity.Property(e => e.BillText).HasDefaultValue("-");
            entity.Property(e => e.NetAmount).HasDefaultValue(0.0);
        });

        modelBuilder.Entity<SalesReturn>(entity =>
        {
            entity.Property(e => e.Srid).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.Property(e => e.Discount).HasDefaultValue(0m, "DF_Settings_Discount");
            entity.Property(e => e.EnablePayroll).HasDefaultValue(true, "DF_Settings_EnablePayroll");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PricePercent).HasDefaultValue(0.0);
            entity.Property(e => e.ReOrder).HasDefaultValue(5m, "DF_Settings_ReOrder");
        });

        modelBuilder.Entity<StoreDetail>(entity =>
        {
            entity.Property(e => e.LogoPath).HasDefaultValue("-", "DF_StoreDetails_LogoPath");
        });

        modelBuilder.Entity<SupplierMaster>(entity =>
        {
            entity.Property(e => e.SupplierId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TblBarcode>(entity =>
        {
            entity.Property(e => e.Sizes).HasDefaultValue("-", "DF_tblBarcode_Sizes");
        });

        modelBuilder.Entity<TblGsttaxReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GSTtblTaxReport");
        });

        modelBuilder.Entity<TblReward>(entity =>
        {
            entity.Property(e => e.IsRedeem).HasDefaultValue("N", "DF_tblRewards_IsRedeem");
        });

        modelBuilder.Entity<TblStartNo>(entity =>
        {
            entity.Property(e => e.CostPercent).HasDefaultValue(0, "DF_tblStartNos_CostPercent");
            entity.Property(e => e.StartBarcode).HasDefaultValue(1, "DF_tblStartNos_StartBarcode");
            entity.Property(e => e.StartBillNo).HasDefaultValue(1, "DF_tblStartNos_StartBillNo");
        });

        modelBuilder.Entity<TransferPurchase>(entity =>
        {
            entity.HasKey(e => e.Trid).HasName("PK_TransferPurchase_PURID");

            entity.Property(e => e.Discount).HasDefaultValue(0, "DC_TransferPurchase_Discount");
        });

        modelBuilder.Entity<Uommaster>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VStock>(entity =>
        {
            entity.ToView("vStock");
        });

        modelBuilder.Entity<VwPurchase>(entity =>
        {
            entity.ToView("vwPurchase");
        });

        modelBuilder.Entity<VwSalesCustomer>(entity =>
        {
            entity.ToView("vwSalesCustomer");
        });

        modelBuilder.Entity<VwStock>(entity =>
        {
            entity.ToView("vwStock");
        });

        modelBuilder.Entity<VwSupplierPurchase>(entity =>
        {
            entity.ToView("vwSupplierPurchase");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
