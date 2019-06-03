using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");

            builder.HasIndex(p => new { p.OrderId, p.ProductId })
                .HasName("order_item_product_idx");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.OrderId)
                .HasColumnName("order_id")
                .IsRequired(true);

            builder.HasOne(p => p.RelatedOrder)
                .WithMany(p => p.OrderItems)
                .HasConstraintName("order_item_order_id_fkey")
                .HasForeignKey(p => p.OrderId)
                .IsRequired(true);

            builder.Property(p => p.ProductId)
                .HasColumnName("product_id")
                .IsRequired(true);

            builder.HasOne(p => p.RelatedProduct)
                .WithMany(p => p.OrderItems)
                .HasConstraintName("order_item_product_id_fkey")
                .HasForeignKey(p => p.ProductId)
                .IsRequired(true);

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("decimal(12,2)")
                .IsRequired(true);

            builder.Property(p => p.Quantity)
                .HasColumnName("quantity")
                .IsRequired(true);
        }
    }
}
