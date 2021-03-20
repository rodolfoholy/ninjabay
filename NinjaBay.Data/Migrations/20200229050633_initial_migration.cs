using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaBay.Data.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "ninja_bay");

            migrationBuilder.CreateTable(
                "key_words",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    word = table.Column<string>("varchar(255)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_key_words", x => x.id); });

            migrationBuilder.CreateTable(
                "logs",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    occurred_at = table.Column<DateTime>("timestamp", nullable: false),
                    level = table.Column<string>("varchar(255)", nullable: true),
                    logger = table.Column<string>("varchar(255)", nullable: true),
                    message = table.Column<string>("text", nullable: true),
                    exception = table.Column<string>("text", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_logs", x => x.id); });

            migrationBuilder.CreateTable(
                "products",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    name = table.Column<string>("Varchar(255)", nullable: false),
                    desciption = table.Column<string>("Varchar(255)", nullable: true),
                    is_active = table.Column<bool>("boolean", nullable: false),
                    quantity = table.Column<int>("int", nullable: false),
                    price = table.Column<decimal>("numeric", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_products", x => x.id); });

            migrationBuilder.CreateTable(
                "users",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    email = table.Column<string>("Varchar(255)", nullable: false),
                    senha = table.Column<string>("Varchar(255)", nullable: false),
                    name = table.Column<string>("Varchar(255)", nullable: false),
                    active = table.Column<bool>("boolean", nullable: false),
                    type = table.Column<string>("varchar(100)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_users", x => x.id); });

            migrationBuilder.CreateTable(
                "product_images",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    image_path = table.Column<string>("text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_images", x => x.id);
                    table.ForeignKey(
                        "FK_product_images_products_ProductId",
                        x => x.ProductId,
                        principalSchema: "ninja_bay",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "product_key_words",
                schema: "ninja_bay",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    KeyWordId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_key_words", x => new {x.ProductId, x.KeyWordId});
                    table.ForeignKey(
                        "FK_product_key_words_key_words_ProductId",
                        x => x.ProductId,
                        principalSchema: "ninja_bay",
                        principalTable: "key_words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_product_key_words_products_ProductId",
                        x => x.ProductId,
                        principalSchema: "ninja_bay",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "product_question_answers",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    question = table.Column<string>("varchar(255)", nullable: true),
                    answer = table.Column<string>("varchar(525)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_question_answers", x => x.id);
                    table.ForeignKey(
                        "FK_product_question_answers_products_ProductId",
                        x => x.ProductId,
                        principalSchema: "ninja_bay",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_key_words_word",
                schema: "ninja_bay",
                table: "key_words",
                column: "word",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_product_images_ProductId",
                schema: "ninja_bay",
                table: "product_images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                "IX_product_question_answers_ProductId",
                schema: "ninja_bay",
                table: "product_question_answers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                "IX_users_email",
                schema: "ninja_bay",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_users_senha",
                schema: "ninja_bay",
                table: "users",
                column: "senha",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "logs",
                "ninja_bay");

            migrationBuilder.DropTable(
                "product_images",
                "ninja_bay");

            migrationBuilder.DropTable(
                "product_key_words",
                "ninja_bay");

            migrationBuilder.DropTable(
                "product_question_answers",
                "ninja_bay");

            migrationBuilder.DropTable(
                "users",
                "ninja_bay");

            migrationBuilder.DropTable(
                "key_words",
                "ninja_bay");

            migrationBuilder.DropTable(
                "products",
                "ninja_bay");
        }
    }
}