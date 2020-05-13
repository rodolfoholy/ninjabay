using Microsoft.EntityFrameworkCore.Migrations;

namespace SenacSp.ProjetoIntegrador.Data.Migrations
{
    public partial class Add_PaidPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "paid_price",
                schema: "senac_ecommerce",
                table: "product_orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paid_price",
                schema: "senac_ecommerce",
                table: "product_orders");
        }
    }
}
