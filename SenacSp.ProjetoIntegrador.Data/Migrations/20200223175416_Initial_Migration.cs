using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SenacSp.ProjetoIntegrador.Data.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "senac_ecommerce");

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
                name: "users",
                schema: "senac_ecommerce");
        }
    }
}
