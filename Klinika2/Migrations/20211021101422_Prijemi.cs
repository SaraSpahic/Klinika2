using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Klinika2.Migrations
{
    public partial class Prijemi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prijem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: true),
                    LjekarId = table.Column<int>(type: "int", nullable: true),
                    Hitno = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prijem_Ljekar_LjekarId",
                        column: x => x.LjekarId,
                        principalTable: "Ljekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prijem_Patients_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prijem_LjekarId",
                table: "Prijem",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijem_PacijentId",
                table: "Prijem",
                column: "PacijentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prijem");
        }
    }
}
