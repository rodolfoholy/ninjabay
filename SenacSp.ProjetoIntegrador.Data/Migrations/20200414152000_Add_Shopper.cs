using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SenacSp.ProjetoIntegrador.Data.Migrations
{
    public partial class Add_Shopper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shoppers",
                schema: "senac_ecommerce",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identification_Number = table.Column<string>(type: "varchar(100)", nullable: true),
                    Identification_Type = table.Column<string>(type: "varchar(100)", nullable: true),
                    addres_information_place_name = table.Column<string>(type: "varchar(255)", nullable: true),
                    addres_information_number = table.Column<string>(type: "varchar(100)", nullable: true),
                    addres_information_complement = table.Column<string>(type: "varchar(100)", nullable: true),
                    addres_information_district = table.Column<string>(type: "varchar(100)", nullable: true),
                    addres_information_zipcode = table.Column<string>(type: "varchar(100)", nullable: true),
                    addres_information_city = table.Column<string>(type: "varchar(255)", nullable: true),
                    addres_information_state = table.Column<string>(type: "varchar(255)", nullable: true),
                    Address_Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppers", x => x.id);
                    table.ForeignKey(
                        name: "FK_shoppers_users_id",
                        column: x => x.id,
                        principalSchema: "senac_ecommerce",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppers_Identification_Number",
                schema: "senac_ecommerce",
                table: "shoppers",
                column: "Identification_Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppers",
                schema: "senac_ecommerce");
        }
    }
}
