using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)

        {

            builder.ToTable("order")

                .HasKey(c => c.Id)

                .HasName("order_id_pkey"); ;



            builder.HasIndex(e => e.CustomerId)

                .HasName("order_customer_id__idx");



            builder.HasIndex(e => e.OrderDate)

                .HasName("order_order_date__idx");



            builder.Property(e => e.Id)

                .HasColumnName("id")

                .UseNpgsqlIdentityColumn()

                .IsRequired();



            builder.Property(e => e.CustomerId).HasColumnName("customer_id");



            builder.Property(e => e.OrderDate)

                .HasColumnName("order_date")

                .HasColumnType("date");



            builder.Property(e => e.OrderNumber)

                .HasColumnName("order_number")

                .HasMaxLength(10)

                .IsRequired();



            builder.Property(e => e.TotalAmount)

                .HasColumnName("total_amount")

                .HasColumnType("numeric(12,2)")

                .HasDefaultValueSql("0")

                .IsRequired();



            builder.HasOne(d => d.Customer)

                .WithMany(p => p.Order)

                .HasForeignKey(d => d.CustomerId)

                .OnDelete(DeleteBehavior.ClientSetNull)

                .HasConstraintName("order__reference_customer__idx");

        }
    }
}
