using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 40, nullable: false),
                    last_name = table.Column<string>(maxLength: 40, nullable: false),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    phone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_id_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(maxLength: 40, nullable: false),
                    contact_name = table.Column<string>(maxLength: 50, nullable: true),
                    contact_title = table.Column<string>(maxLength: 40, nullable: true),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    phone = table.Column<string>(maxLength: 30, nullable: true),
                    fax = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("supplier_id_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_date = table.Column<DateTime>(type: "date", nullable: false),
                    order_number = table.Column<string>(maxLength: 10, nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(12,2)", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("order_id_pkey", x => x.id);
                    table.ForeignKey(
                        name: "order__reference_customer__idx",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(maxLength: 50, nullable: false),
                    supplier_id = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(12,2)", nullable: true, defaultValueSql: "0"),
                    package = table.Column<string>(maxLength: 30, nullable: true),
                    is_discontinued = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_id_pkey", x => x.id);
                    table.ForeignKey(
                        name: "product__reference_supplier__fkey",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    quantity = table.Column<int>(nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("order_item__id__pkey", x => x.id);
                    table.ForeignKey(
                        name: "order_item__reference_order__fkey",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "order_item__reference_product__fkey",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "customer_name_idx",
                table: "customer",
                columns: new[] { "last_name", "first_name" });

            migrationBuilder.CreateIndex(
                name: "order_customer_id__idx",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "order_order_date__idx",
                table: "order",
                column: "order_date");

            migrationBuilder.CreateIndex(
                name: "order_item__order_id__idx",
                table: "order_item",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "order_item__produc_tid__idx",
                table: "order_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "product_name_idx",
                table: "product",
                column: "product_name");

            migrationBuilder.CreateIndex(
                name: "product__supplier_id__idx",
                table: "product",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "supplier_name_idx",
                table: "supplier",
                column: "company_name");

            migrationBuilder.CreateIndex(
                name: "supplier_country_idx",
                table: "supplier",
                column: "country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "supplier");
        }
    }
}
