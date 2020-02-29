using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SenacSp.ProjetoIntegrador.Data.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "senac_ecommerce");

            migrationBuilder.CreateTable(
                name: "key_words",
                schema: "senac_ecommerce",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    word = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_key_words", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logs",
                schema: "senac_ecommerce",
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
                schema: "senac_ecommerce",
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
                name: "users",
                schema: "senac_ecommerce",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "Varchar(255)", nullable: false),
                    senha = table.Column<string>(type: "Varchar(255)", nullable: false),
                    name = table.Column<string>(type: "Varchar(255)", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    type = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_images",
                schema: "senac_ecommerce",
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
                        principalSchema: "senac_ecommerce",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_key_words",
                schema: "senac_ecommerce",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    KeyWordId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_key_words", x => new { x.ProductId, x.KeyWordId });
                    table.ForeignKey(
                        name: "FK_product_key_words_key_words_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "senac_ecommerce",
                        principalTable: "key_words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_key_words_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "senac_ecommerce",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_question_answers",
                schema: "senac_ecommerce",
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
                        principalSchema: "senac_ecommerce",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_key_words_word",
                schema: "senac_ecommerce",
                table: "key_words",
                column: "word",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_images_ProductId",
                schema: "senac_ecommerce",
                table: "product_images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_question_answers_ProductId",
                schema: "senac_ecommerce",
                table: "product_question_answers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                schema: "senac_ecommerce",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_senha",
                schema: "senac_ecommerce",
                table: "users",
                column: "senha",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs",
                schema: "senac_ecommerce");

            migrationBuilder.DropTable(
                name: "product_images",
                schema: "senac_ecommerce");

            migrationBuilder.DropTable(
                name: "product_key_words",
                schema: "senac_ecommerce");

            migrationBuilder.DropTable(
                name: "product_question_answers",
                schema: "senac_ecommerce");

            migrationBuilder.DropTable(
                name: "users",
                schema: "senac_ecommerce");

            migrationBuilder.DropTable(
                name: "key_words",
                schema: "senac_ecommerce");

            migrationBuilder.DropTable(
                name: "products",
                schema: "senac_ecommerce");
        }
    }
}
