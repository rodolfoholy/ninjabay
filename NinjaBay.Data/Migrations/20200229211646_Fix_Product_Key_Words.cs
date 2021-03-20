using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaBay.Data.Migrations
{
    public partial class Fix_Product_Key_Words : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_product_key_words_key_words_ProductId",
                schema: "ninja_bay",
                table: "product_key_words");

            migrationBuilder.AlterColumn<string>(
                "word",
                schema: "ninja_bay",
                table: "key_words",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.CreateIndex(
                "IX_product_key_words_KeyWordId",
                schema: "ninja_bay",
                table: "product_key_words",
                column: "KeyWordId");

            migrationBuilder.AddForeignKey(
                "FK_product_key_words_key_words_KeyWordId",
                schema: "ninja_bay",
                table: "product_key_words",
                column: "KeyWordId",
                principalSchema: "ninja_bay",
                principalTable: "key_words",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_product_key_words_key_words_KeyWordId",
                schema: "ninja_bay",
                table: "product_key_words");

            migrationBuilder.DropIndex(
                "IX_product_key_words_KeyWordId",
                schema: "ninja_bay",
                table: "product_key_words");

            migrationBuilder.AlterColumn<string>(
                "word",
                schema: "ninja_bay",
                table: "key_words",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                "FK_product_key_words_key_words_ProductId",
                schema: "ninja_bay",
                table: "product_key_words",
                column: "ProductId",
                principalSchema: "ninja_bay",
                principalTable: "key_words",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}