using Microsoft.EntityFrameworkCore;
using WebAPI.Models.WebPOSAPI.Models;
using WebAPI.ViewModels;


namespace WebAPI.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<ShopNames> ShopNames { get; set; }
        public DbSet<BarcodeStart> BarcodeStart { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<PaymentTypes> PaymentTypes { get; set; }

        public DbSet<Settings> Settings { get; set; }
        public DbSet<SaleItems> SaleItems { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<WebAPI.ViewModels.StockViewModel> StockReport { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Ensure auto-increment


                entity.HasMany(s => s.SaleItems)
                      .WithOne(si => si.Sale)
                      .HasForeignKey(si => si.SaleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<StockViewModel>()
                .HasNoKey();



            builder.Entity<SaleItems>()
    .HasOne(s => s.Sizes)
    .WithMany()
    .HasForeignKey(s => s.SizeId);

        }
    }
}
