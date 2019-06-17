using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)

        {

            builder.ToTable("order_item")

                .HasKey(c => c.Id)

                .HasName("order_item__id__pkey"); ;



            builder.HasIndex(e => e.OrderId)

                .HasName("order_item__order_id__idx");



            builder.HasIndex(e => e.ProductId)

                .HasName("order_item__produc_tid__idx");



            builder.Property(e => e.Id)

                .HasColumnName("id")

                .UseNpgsqlIdentityColumn();



            builder.Property(e => e.OrderId)

                .HasColumnName("order_id")

                .IsRequired();



            builder.Property(e => e.ProductId)

                .HasColumnName("product_id")

                .IsRequired();



            builder.Property(e => e.Quantity)

                .HasColumnName("quantity")

                .HasDefaultValueSql("1")

                .IsRequired();



            builder.Property(e => e.UnitPrice)

                .HasColumnName("unit_price")

                .HasColumnType("numeric(12,2)")

                .IsRequired();



            builder.HasOne(d => d.Order)

                .WithMany(p => p.OrderItem)

                .HasForeignKey(d => d.OrderId)

                .OnDelete(DeleteBehavior.ClientSetNull)

                .HasConstraintName("order_item__reference_order__fkey");



            builder.HasOne(d => d.Product)

                .WithMany(p => p.OrderItem)

                .HasForeignKey(d => d.ProductId)

                .OnDelete(DeleteBehavior.ClientSetNull)

                .HasConstraintName("order_item__reference_product__fkey");

        }
    }
}
