using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NinjaBay.Data.Migrations
{
    public partial class Add_Fields_sprint5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "addres_information_city",
                schema: "ninja_bay",
                table: "shoppers");

            migrationBuilder.DropColumn(
                "addres_information_complement",
                schema: "ninja_bay",
                table: "shoppers");

            migrationBuilder.DropColumn(
                "Address_Country",
                schema: "ninja_bay",
                table: "shoppers");

            migrationBuilder.DropColumn(
                "addres_information_district",
                schema: "ninja_bay",
                table: "shoppers");

            migrationBuilder.DropColumn(
                "addres_information_number",
                schema: "ninja_bay",
                table: "shoppers");

            migrationBuilder.DropColumn(
                "addres_information_place_name",
                schema: "ninja_bay",
                table: "shoppers");

            migrationBuilder.DropColumn(
                "addres_information_state",
                schema: "ninja_bay",
                table: "shoppers");

            migrationBuilder.DropColumn(
                "addres_information_zipcode",
                schema: "ninja_bay",
                table: "shoppers");

            migrationBuilder.CreateTable(
                "shopper_addresses",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    ShopperId = table.Column<Guid>(nullable: false),
                    name = table.Column<string>("Varchar(255)", nullable: false),
                    type = table.Column<string>("varchar(100)", nullable: false),
                    addres_information_place_name = table.Column<string>("varchar(255)", nullable: true),
                    addres_information_number = table.Column<string>("varchar(100)", nullable: true),
                    addres_information_complement = table.Column<string>("varchar(100)", nullable: true),
                    addres_information_district = table.Column<string>("varchar(100)", nullable: true),
                    addres_information_zipcode = table.Column<string>("varchar(100)", nullable: true),
                    addres_information_city = table.Column<string>("varchar(255)", nullable: true),
                    addres_information_state = table.Column<string>("varchar(255)", nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    ShopperId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopper_addresses", x => x.id);
                    table.ForeignKey(
                        "FK_shopper_addresses_shoppers_ShopperId",
                        x => x.ShopperId,
                        principalSchema: "ninja_bay",
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_shopper_addresses_shoppers_ShopperId1",
                        x => x.ShopperId1,
                        principalSchema: "ninja_bay",
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "orders",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    OrderIdentifier = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>("timestamp", nullable: false),
                    ShopperId = table.Column<Guid>(nullable: false),
                    ShippingAddressId = table.Column<Guid>(nullable: false),
                    payment_method = table.Column<string>("varchar(100)", nullable: false),
                    payment_status = table.Column<string>("varchar(100)", nullable: false),
                    price = table.Column<decimal>("numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        "FK_orders_shopper_addresses_ShippingAddressId",
                        x => x.ShippingAddressId,
                        principalSchema: "ninja_bay",
                        principalTable: "shopper_addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_orders_shoppers_ShopperId",
                        x => x.ShopperId,
                        principalSchema: "ninja_bay",
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "product_orders",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    quantity = table.Column<int>("int", nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_orders", x => x.id);
                    table.ForeignKey(
                        "FK_product_orders_orders_OrderId",
                        x => x.OrderId,
                        principalSchema: "ninja_bay",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_product_orders_products_ProductId",
                        x => x.ProductId,
                        principalSchema: "ninja_bay",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_orders_ShippingAddressId",
                schema: "ninja_bay",
                table: "orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                "IX_orders_ShopperId",
                schema: "ninja_bay",
                table: "orders",
                column: "ShopperId");

            migrationBuilder.CreateIndex(
                "IX_product_orders_OrderId",
                schema: "ninja_bay",
                table: "product_orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                "IX_product_orders_ProductId",
                schema: "ninja_bay",
                table: "product_orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                "IX_shopper_addresses_ShopperId",
                schema: "ninja_bay",
                table: "shopper_addresses",
                column: "ShopperId");

            migrationBuilder.CreateIndex(
                "IX_shopper_addresses_ShopperId1",
                schema: "ninja_bay",
                table: "shopper_addresses",
                column: "ShopperId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "product_orders",
                "ninja_bay");

            migrationBuilder.DropTable(
                "orders",
                "ninja_bay");

            migrationBuilder.DropTable(
                "shopper_addresses",
                "ninja_bay");

            migrationBuilder.AddColumn<string>(
                "addres_information_city",
                schema: "ninja_bay",
                table: "shoppers",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "addres_information_complement",
                schema: "ninja_bay",
                table: "shoppers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Address_Country",
                schema: "ninja_bay",
                table: "shoppers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "addres_information_district",
                schema: "ninja_bay",
                table: "shoppers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "addres_information_number",
                schema: "ninja_bay",
                table: "shoppers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "addres_information_place_name",
                schema: "ninja_bay",
                table: "shoppers",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "addres_information_state",
                schema: "ninja_bay",
                table: "shoppers",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "addres_information_zipcode",
                schema: "ninja_bay",
                table: "shoppers",
                type: "varchar(100)",
                nullable: true);
        }
    }
}