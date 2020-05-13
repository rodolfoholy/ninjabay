using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SenacSp.ProjetoIntegrador.Data.Migrations
{
    public partial class Add_Fields_sprint5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "addres_information_city",
                schema: "senac_ecommerce",
                table: "shoppers");

            migrationBuilder.DropColumn(
                name: "addres_information_complement",
                schema: "senac_ecommerce",
                table: "shoppers");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "senac_ecommerce",
                table: "shoppers");

            migrationBuilder.DropColumn(
                name: "addres_information_district",
                schema: "senac_ecommerce",
                table: "shoppers");

            migrationBuilder.DropColumn(
                name: "addres_information_number",
                schema: "senac_ecommerce",
                table: "shoppers");

            migrationBuilder.DropColumn(
                name: "addres_information_place_name",
                schema: "senac_ecommerce",
                table: "shoppers");

            migrationBuilder.DropColumn(
                name: "addres_information_state",
                schema: "senac_ecommerce",
                table: "shoppers");

            migrationBuilder.DropColumn(
                name: "addres_information_zipcode",
                schema: "senac_ecommerce",
                table: "shoppers");

            migrationBuilder.CreateTable(
                name: "shopper_addresses",
                schema: "senac_ecommerce",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShopperId = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "Varchar(255)", nullable: false),
                    type = table.Column<string>(type: "varchar(100)", nullable: false),
                    addres_information_place_name = table.Column<string>(type: "varchar(255)", nullable: true),
                    addres_information_number = table.Column<string>(type: "varchar(100)", nullable: true),
                    addres_information_complement = table.Column<string>(type: "varchar(100)", nullable: true),
                    addres_information_district = table.Column<string>(type: "varchar(100)", nullable: true),
                    addres_information_zipcode = table.Column<string>(type: "varchar(100)", nullable: true),
                    addres_information_city = table.Column<string>(type: "varchar(255)", nullable: true),
                    addres_information_state = table.Column<string>(type: "varchar(255)", nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    ShopperId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopper_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_shopper_addresses_shoppers_ShopperId",
                        column: x => x.ShopperId,
                        principalSchema: "senac_ecommerce",
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shopper_addresses_shoppers_ShopperId1",
                        column: x => x.ShopperId1,
                        principalSchema: "senac_ecommerce",
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "senac_ecommerce",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderIdentifier = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ShopperId = table.Column<Guid>(nullable: false),
                    ShippingAddressId = table.Column<Guid>(nullable: false),
                    payment_method = table.Column<string>(type: "varchar(100)", nullable: false),
                    payment_status = table.Column<string>(type: "varchar(100)", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_shopper_addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalSchema: "senac_ecommerce",
                        principalTable: "shopper_addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_shoppers_ShopperId",
                        column: x => x.ShopperId,
                        principalSchema: "senac_ecommerce",
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_orders",
                schema: "senac_ecommerce",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_orders_orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "senac_ecommerce",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_orders_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "senac_ecommerce",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_ShippingAddressId",
                schema: "senac_ecommerce",
                table: "orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ShopperId",
                schema: "senac_ecommerce",
                table: "orders",
                column: "ShopperId");

            migrationBuilder.CreateIndex(
                name: "IX_product_orders_OrderId",
                schema: "senac_ecommerce",
                table: "product_orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_product_orders_ProductId",
                schema: "senac_ecommerce",
                table: "product_orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_shopper_addresses_ShopperId",
                schema: "senac_ecommerce",
                table: "shopper_addresses",
                column: "ShopperId");

            migrationBuilder.CreateIndex(
                name: "IX_shopper_addresses_ShopperId1",
                schema: "senac_ecommerce",
                table: "shopper_addresses",
                column: "ShopperId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_orders",
                schema: "senac_ecommerce");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "senac_ecommerce");

            migrationBuilder.DropTable(
                name: "shopper_addresses",
                schema: "senac_ecommerce");

            migrationBuilder.AddColumn<string>(
                name: "addres_information_city",
                schema: "senac_ecommerce",
                table: "shoppers",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "addres_information_complement",
                schema: "senac_ecommerce",
                table: "shoppers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "senac_ecommerce",
                table: "shoppers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "addres_information_district",
                schema: "senac_ecommerce",
                table: "shoppers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "addres_information_number",
                schema: "senac_ecommerce",
                table: "shoppers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "addres_information_place_name",
                schema: "senac_ecommerce",
                table: "shoppers",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "addres_information_state",
                schema: "senac_ecommerce",
                table: "shoppers",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "addres_information_zipcode",
                schema: "senac_ecommerce",
                table: "shoppers",
                type: "varchar(100)",
                nullable: true);
        }
    }
}
