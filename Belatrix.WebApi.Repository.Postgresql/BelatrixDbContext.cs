using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.Postgresql.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Belatrix.WebApi.Repository.Postgresql
{
    public class BelatrixDbContext : DbContext, IBelatrixDbContext
    {
        public BelatrixDbContext(DbContextOptions<BelatrixDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfig());
            modelBuilder.ApplyConfiguration<Supplier>(new SupplierConfig());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfig());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfig());
            modelBuilder.ApplyConfiguration<OrderItem>(new OrderItemConfig());
        }

        DbSet<Customer> Customer { get; set; }
        DbSet<Supplier> Supplier { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<OrderItem> OrderItem { get; set; }
    }
}
