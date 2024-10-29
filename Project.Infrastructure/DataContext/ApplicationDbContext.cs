using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Domail.Entities;
using Project.Infrastructure.Identity;

namespace Project.Infrastructure.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ProductSize>? productSizes { get; set; }
        public DbSet<Retailer> ? railers { get; set; }
        public DbSet<Company> ? companies { get; set; }
        public DbSet<DeliveryAddress>? deliveryAddresses { get; set;}
        public DbSet<Order> ? orders { get; set; }
        public DbSet<ProdReturn>? prodReturns { get; set; }
        public DbSet<Product> ? products { get; set; }
        public DbSet<Stock> ? stacks {  get; set; }
        public DbSet<Trader> ? traders { get; set; }
        public DbSet<Valve> ? valves { get; set; }
        public DbSet<OrderDetail> orderDetail { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<PurchaseDetail> purchaseDetails { get; set; }
        public DbSet<ProductDiscunt> ? productDiscunts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Trader)
                .WithMany()
                .HasForeignKey(s => s.TraderId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany()
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete on OrderID

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<IdentityUserLogin<string>>();
            modelBuilder.Entity<PurchaseDetail>()
                .HasOne(pd => pd.Product)
                .WithMany()
                .HasForeignKey(pd => pd.ProductID)
                .OnDelete(DeleteBehavior.NoAction); // No cascade on ProductID

            modelBuilder.Entity<PurchaseDetail>()
                .HasOne(pd => pd.Purchase)
                .WithMany(p => p.PurchaseDetails)
                .HasForeignKey(pd => pd.PurchaseID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade on PurchaseID
        }
    }
    
}
