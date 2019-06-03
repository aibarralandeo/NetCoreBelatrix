using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("supplier");

            builder.HasIndex(p => new { p.ContactName, p.Country })
                .HasName("supplier_name_idx");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.CompanyName)
                .HasColumnName("company_name")
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(p => p.ContactName)
                .HasColumnName("contact_name")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(p => p.ContactTitle)
                .HasColumnName("contact_title")
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(p => p.City)
                .HasColumnName("city")
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(p => p.Country)
                .HasColumnName("country")
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(p => p.Phone)
                .HasColumnName("phone")
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(p => p.Fax)
                .HasColumnName("fax")
                .HasMaxLength(30)
                .IsRequired(true);
        }
    }
}
