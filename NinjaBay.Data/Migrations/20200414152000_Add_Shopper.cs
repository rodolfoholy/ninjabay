using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaBay.Data.Migrations
{
    public partial class Add_Shopper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "shoppers",
                schema: "ninja_bay",
                columns: table => new
                {
                    id = table.Column<Guid>("uuid", nullable: false),
                    Identification_Number = table.Column<string>("varchar(100)", nullable: true),
                    Identification_Type = table.Column<string>("varchar(100)", nullable: true),
                    addres_information_place_name = table.Column<string>("varchar(255)", nullable: true),
                    addres_information_number = table.Column<string>("varchar(100)", nullable: true),
                    addres_information_complement = table.Column<string>("varchar(100)", nullable: true),
                    addres_information_district = table.Column<string>("varchar(100)", nullable: true),
                    addres_information_zipcode = table.Column<string>("varchar(100)", nullable: true),
                    addres_information_city = table.Column<string>("varchar(255)", nullable: true),
                    addres_information_state = table.Column<string>("varchar(255)", nullable: true),
                    Address_Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppers", x => x.id);
                    table.ForeignKey(
                        "FK_shoppers_users_id",
                        x => x.id,
                        principalSchema: "ninja_bay",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_shoppers_Identification_Number",
                schema: "ninja_bay",
                table: "shoppers",
                column: "Identification_Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "shoppers",
                "ninja_bay");
        }
    }
}