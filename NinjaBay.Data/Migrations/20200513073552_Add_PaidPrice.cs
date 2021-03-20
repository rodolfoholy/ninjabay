using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaBay.Data.Migrations
{
    public partial class Add_PaidPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                "paid_price",
                schema: "ninja_bay",
                table: "product_orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "paid_price",
                schema: "ninja_bay",
                table: "product_orders");
        }
    }
}