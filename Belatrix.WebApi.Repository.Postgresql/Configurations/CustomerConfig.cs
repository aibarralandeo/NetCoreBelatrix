using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {


            builder.ToTable("customer")

                .HasKey(c => c.Id)

                .HasName("customer_id_pkey");



            builder.HasIndex(e => new { e.LastName, e.FirstName })

                .HasName("customer_name_idx");



            builder.Property(e => e.Id)

                .HasColumnName("id")

                .UseNpgsqlIdentityColumn();



            builder.Property(e => e.City)

                .HasColumnName("city")

                .HasMaxLength(40);



            builder.Property(e => e.Country)

                .HasColumnName("country")

                .HasMaxLength(40);



            builder.Property(e => e.FirstName)

                .IsRequired()

                .HasColumnName("first_name")

                .HasMaxLength(40);



            builder.Property(e => e.LastName)

                .IsRequired()

                .HasColumnName("last_name")

                .HasMaxLength(40);



            builder.Property(e => e.Phone)

                .HasColumnName("phone")

                .HasMaxLength(20);

        }
    }    
}
