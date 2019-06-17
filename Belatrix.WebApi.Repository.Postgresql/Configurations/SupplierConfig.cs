using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)

        {

            builder.ToTable("supplier")

                .HasKey(c => c.Id)

                .HasName("supplier_id_pkey"); ;



            builder.HasIndex(e => e.CompanyName)

                .HasName("supplier_name_idx");



            builder.HasIndex(e => e.Country)

                .HasName("supplier_country_idx");



            builder.Property(e => e.Id)

                .HasColumnName("id")

                .UseNpgsqlIdentityColumn()

                .IsRequired();



            builder.Property(e => e.City)

                .HasColumnName("city")

                .HasMaxLength(40);



            builder.Property(e => e.CompanyName)

                .HasColumnName("company_name")

                .HasMaxLength(40)

                .IsRequired();



            builder.Property(e => e.ContactName)

                .HasColumnName("contact_name")

                .HasMaxLength(50);



            builder.Property(e => e.ContactTitle)

                .HasColumnName("contact_title")

                .HasMaxLength(40);



            builder.Property(e => e.Country)

                .HasColumnName("country")

                .HasMaxLength(40);



            builder.Property(e => e.Fax)

                .HasColumnName("fax")

                .HasMaxLength(30);



            builder.Property(e => e.Phone)

                .HasColumnName("phone")

                .HasMaxLength(30);

        }
    }
}
