using Microsoft.EntityFrameworkCore.Migrations;

namespace SenacSp.ProjetoIntegrador.Data.Migrations
{
    public partial class Fix_Product_Key_Words : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_key_words_key_words_ProductId",
                schema: "senac_ecommerce",
                table: "product_key_words");

            migrationBuilder.AlterColumn<string>(
                name: "word",
                schema: "senac_ecommerce",
                table: "key_words",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.CreateIndex(
                name: "IX_product_key_words_KeyWordId",
                schema: "senac_ecommerce",
                table: "product_key_words",
                column: "KeyWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_key_words_key_words_KeyWordId",
                schema: "senac_ecommerce",
                table: "product_key_words",
                column: "KeyWordId",
                principalSchema: "senac_ecommerce",
                principalTable: "key_words",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_key_words_key_words_KeyWordId",
                schema: "senac_ecommerce",
                table: "product_key_words");

            migrationBuilder.DropIndex(
                name: "IX_product_key_words_KeyWordId",
                schema: "senac_ecommerce",
                table: "product_key_words");

            migrationBuilder.AlterColumn<string>(
                name: "word",
                schema: "senac_ecommerce",
                table: "key_words",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_key_words_key_words_ProductId",
                schema: "senac_ecommerce",
                table: "product_key_words",
                column: "ProductId",
                principalSchema: "senac_ecommerce",
                principalTable: "key_words",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
