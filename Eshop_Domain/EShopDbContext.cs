using Eshop_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eshop_Domain
{
    public class EShopDbContext : DbContext
    {
        public EShopDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Order> Order { get; set; }

        public virtual DbSet<OrderItem> OrderItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);
          
            });

        }
    }
}