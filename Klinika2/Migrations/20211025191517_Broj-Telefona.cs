using Microsoft.EntityFrameworkCore.Migrations;

namespace Klinika2.Migrations
{
    public partial class BrojTelefona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prijem_Ljekar_LjekarId",
                table: "Prijem");

            migrationBuilder.DropForeignKey(
                name: "FK_Prijem_Patients_PacijentId",
                table: "Prijem");

            migrationBuilder.AlterColumn<int>(
                name: "PacijentId",
                table: "Prijem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LjekarId",
                table: "Prijem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrojTelefona",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prijem_Ljekar_LjekarId",
                table: "Prijem",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prijem_Patients_PacijentId",
                table: "Prijem",
                column: "PacijentId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prijem_Ljekar_LjekarId",
                table: "Prijem");

            migrationBuilder.DropForeignKey(
                name: "FK_Prijem_Patients_PacijentId",
                table: "Prijem");

            migrationBuilder.DropColumn(
                name: "BrojTelefona",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "PacijentId",
                table: "Prijem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LjekarId",
                table: "Prijem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prijem_Ljekar_LjekarId",
                table: "Prijem",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prijem_Patients_PacijentId",
                table: "Prijem",
                column: "PacijentId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
