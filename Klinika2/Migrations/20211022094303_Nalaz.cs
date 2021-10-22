using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Klinika2.Migrations
{
    public partial class Nalaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nalaz",
                columns: table => new
                {
                    PrijemID = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nalaz", x => x.PrijemID);
                    table.ForeignKey(
                        name: "FK_Nalaz_Prijem_PrijemID",
                        column: x => x.PrijemID,
                        principalTable: "Prijem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nalaz");
        }
    }
}
