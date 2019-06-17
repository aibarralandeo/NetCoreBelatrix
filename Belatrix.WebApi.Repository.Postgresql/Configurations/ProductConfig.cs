using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)

        {

            builder.ToTable("product")

                .HasKey(c => c.Id)

                .HasName("product_id_pkey"); ;



            builder.HasIndex(e => e.ProductName)

                .HasName("product_name_idx");



            builder.HasIndex(e => e.SupplierId)

                .HasName("product__supplier_id__idx");



            builder.Property(e => e.Id)

                .HasColumnName("id")

                .UseNpgsqlIdentityColumn();



            builder.Property(e => e.IsDiscontinued)

                .HasColumnName("is_discontinued")

                .IsRequired();



            builder.Property(e => e.Package)

                .HasColumnName("package")

                .HasMaxLength(30);



            builder.Property(e => e.ProductName)

                .HasColumnName("product_name")

                .HasMaxLength(50)

                .IsRequired();



            builder.Property(e => e.SupplierId)

                .HasColumnName("supplier_id")

                .IsRequired();



            builder.Property(e => e.UnitPrice)

                .HasColumnName("unit_price")

                .HasColumnType("numeric(12,2)")

                .HasDefaultValueSql("0");



            builder.HasOne(d => d.Supplier)

                .WithMany(p => p.Product)

                .HasForeignKey(d => d.SupplierId)

                .OnDelete(DeleteBehavior.ClientSetNull)

                .HasConstraintName("product__reference_supplier__fkey");

        }
    }
}
