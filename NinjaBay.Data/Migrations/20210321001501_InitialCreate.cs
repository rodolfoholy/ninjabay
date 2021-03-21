using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NinjaBay.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ninja_bay");

            migrationBuilder.CreateTable(
                name: "key_words",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    word = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_key_words", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logs",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    occurred_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    level = table.Column<string>(type: "varchar(255)", nullable: true),
                    logger = table.Column<string>(type: "varchar(255)", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    exception = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "Varchar(255)", nullable: false),
                    desciption = table.Column<string>(type: "Varchar(255)", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "ninja_bay",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product_images",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    image_path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_images_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ninja_bay",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_key_words",
                schema: "ninja_bay",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    KeyWordId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_key_words", x => new { x.ProductId, x.KeyWordId });
                    table.ForeignKey(
                        name: "FK_product_key_words_key_words_KeyWordId",
                        column: x => x.KeyWordId,
                        principalSchema: "ninja_bay",
                        principalTable: "key_words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_key_words_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ninja_bay",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_question_answers",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    question = table.Column<string>(type: "varchar(255)", nullable: true),
                    answer = table.Column<string>(type: "varchar(525)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_question_answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_question_answers_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ninja_bay",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shoppers",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identification_Number = table.Column<string>(type: "varchar(100)", nullable: true),
                    Identification_Type = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppers", x => x.id);
                    table.ForeignKey(
                        name: "FK_shoppers_User_id",
                        column: x => x.id,
                        principalSchema: "ninja_bay",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopper_addresses",
                schema: "ninja_bay",
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
                        principalSchema: "ninja_bay",
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shopper_addresses_shoppers_ShopperId1",
                        column: x => x.ShopperId1,
                        principalSchema: "ninja_bay",
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "ninja_bay",
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
                        principalSchema: "ninja_bay",
                        principalTable: "shopper_addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_shoppers_ShopperId",
                        column: x => x.ShopperId,
                        principalSchema: "ninja_bay",
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_orders",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    paid_price = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_orders_orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "ninja_bay",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_orders_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ninja_bay",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_key_words_word",
                schema: "ninja_bay",
                table: "key_words",
                column: "word",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_ShippingAddressId",
                schema: "ninja_bay",
                table: "orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ShopperId",
                schema: "ninja_bay",
                table: "orders",
                column: "ShopperId");

            migrationBuilder.CreateIndex(
                name: "IX_product_images_ProductId",
                schema: "ninja_bay",
                table: "product_images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_key_words_KeyWordId",
                schema: "ninja_bay",
                table: "product_key_words",
                column: "KeyWordId");

            migrationBuilder.CreateIndex(
                name: "IX_product_orders_OrderId",
                schema: "ninja_bay",
                table: "product_orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_product_orders_ProductId",
                schema: "ninja_bay",
                table: "product_orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_question_answers_ProductId",
                schema: "ninja_bay",
                table: "product_question_answers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_shopper_addresses_ShopperId",
                schema: "ninja_bay",
                table: "shopper_addresses",
                column: "ShopperId");

            migrationBuilder.CreateIndex(
                name: "IX_shopper_addresses_ShopperId1",
                schema: "ninja_bay",
                table: "shopper_addresses",
                column: "ShopperId1");

            migrationBuilder.CreateIndex(
                name: "IX_shoppers_Identification_Number",
                schema: "ninja_bay",
                table: "shoppers",
                column: "Identification_Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "product_images",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "product_key_words",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "product_orders",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "product_question_answers",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "key_words",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "products",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "shopper_addresses",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "shoppers",
                schema: "ninja_bay");

            migrationBuilder.DropTable(
                name: "User",
                schema: "ninja_bay");
        }
    }
}
