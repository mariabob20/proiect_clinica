using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_clinica.Migrations
{
    public partial class SchimbareDurata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Durata",
                table: "Serviciu",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Durata",
                table: "Serviciu",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
