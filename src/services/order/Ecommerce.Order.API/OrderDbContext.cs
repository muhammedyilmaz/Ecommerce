using Microsoft.EntityFrameworkCore;
using Ecommerce.Order.API.Entities;

namespace Ecommerce.Order.API
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Entities.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(o => o.Id);

                entity.Property(o => o.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(o => o.CustomerId).IsRequired();
                entity.Property(o => o.OrderDate).IsRequired();
                entity.Property(o => o.Status).HasDefaultValue(Enums.OrderStatus.Pending);
                entity.Property(o => o.TotalAmount).HasPrecision(18, 2);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems");
                entity.HasKey(oi => oi.Id);

                entity.Property(oi => oi.Id)
                      .ValueGeneratedOnAdd(); 

                entity.Property(oi => oi.OrderId).IsRequired();
                entity.Property(oi => oi.ProductId).IsRequired();
                entity.Property(oi => oi.ProductName).HasMaxLength(100).IsRequired();
                entity.Property(oi => oi.UnitPrice).HasPrecision(18, 2);
                entity.Property(oi => oi.Quantity).IsRequired();
            });
        }
    }
}
