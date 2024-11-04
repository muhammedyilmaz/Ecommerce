using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Notification.API
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }

        public DbSet<Entities.Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.Notification>(entity =>
            {
                entity.ToTable("Notifications"); 
                entity.HasKey(n => n.Id); 

                entity.Property(n => n.Id)
                    .ValueGeneratedOnAdd(); 

                entity.Property(n => n.UserId)
                    .IsRequired();

                entity.Property(n => n.Message)
                    .IsRequired();

                entity.Property(o => o.Type)
                .HasDefaultValue(Enums.NotificationType.Email)
                .IsRequired();

                entity.Property(n => n.SentAt)
                    .IsRequired();

                entity.Property(n => n.IsSuccess)
                    .IsRequired();
            });
        }
    }
}