﻿// <auto-generated />
using System;
using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.WebApi.Repository.Postgresql.Migrations
{
    [DbContext(typeof(BelatrixDbContext))]
    partial class BelatrixDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Belatrix.WebApi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .HasColumnName("country")
                        .HasMaxLength(40);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(40);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("LastName", "FirstName")
                        .HasName("customer_name_idx");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("order_date");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnName("order_number")
                        .HasMaxLength(10);

                    b.Property<decimal?>("TotalAmount")
                        .IsRequired()
                        .HasColumnName("total_amount")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId", "OrderDate")
                        .HasName("order_customer_idx");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderId")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("unit_price")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("OrderId", "ProductId")
                        .HasName("order_item_product_idx");

                    b.ToTable("order_item");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDiscontinued")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("is_discontinued")
                        .HasDefaultValue(false);

                    b.Property<string>("Package")
                        .IsRequired()
                        .HasColumnName("package")
                        .HasMaxLength(30);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("product_name")
                        .HasMaxLength(50);

                    b.Property<int>("SupplierId")
                        .HasColumnName("supplier_id");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnName("unit_price")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId", "ProductName")
                        .HasName("product_name_idx");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasMaxLength(40);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("company_name")
                        .HasMaxLength(40);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnName("contact_name")
                        .HasMaxLength(50);

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnName("contact_title")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasMaxLength(40);

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnName("fax")
                        .HasMaxLength(30);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("ContactName", "Country")
                        .HasName("supplier_name_idx");

                    b.ToTable("supplier");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Order", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Customer", "RelatedCustomer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("order_customer_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.OrderItem", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Order", "RelatedOrder")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("order_item_order_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Belatrix.WebApi.Models.Product", "RelatedProduct")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("order_item_product_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Product", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Supplier", "RelatedSupplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("product_supplier_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
