using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasIndex(p => new { p.CustomerId, p.OrderDate })
                .HasName("order_customer_idx");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.OrderDate)
                .HasColumnName("order_date")
                .IsRequired(true);

            builder.Property(p => p.OrderNumber)
                .HasColumnName("order_number")
                .HasMaxLength(10)
                .IsRequired(true);

            builder.Property(p => p.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired(true);

            builder.HasOne(p => p.RelatedCustomer)
                .WithMany(p => p.Orders)
                .HasConstraintName("order_customer_id_fkey")
                .HasForeignKey(p => p.CustomerId)
                .IsRequired(true);

            builder.Property(p => p.TotalAmount)
                .HasColumnName("total_amount")
                .HasColumnType("decimal(12,2)")
                .IsRequired(true);
        }
    }
}
