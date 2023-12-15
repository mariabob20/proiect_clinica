using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_clinica.Migrations
{
    public partial class Angajare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Angajat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAngajare",
                table: "Angajat",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Angajat");

            migrationBuilder.DropColumn(
                name: "DataAngajare",
                table: "Angajat");
        }
    }
}
