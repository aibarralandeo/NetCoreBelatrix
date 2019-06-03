using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasIndex(p => new { p.SupplierId, p.ProductName })
                .HasName("product_name_idx");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.ProductName)
                .HasColumnName("product_name")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(p => p.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired(true);

            builder.HasOne(p => p.RelatedSupplier)
                .WithMany(p => p.Products)
                .HasConstraintName("product_supplier_id_fkey")
                .HasForeignKey(p => p.SupplierId)
                .IsRequired(true);

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("decimal(12,2)")
                .IsRequired(false);

            builder.Property(p => p.Package)
                .HasColumnName("package")
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(p => p.IsDiscontinued)
                .HasColumnName("is_discontinued")
                .HasDefaultValue(false)
                .IsRequired(true);
        }
    }
}
