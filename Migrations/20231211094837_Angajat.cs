using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_clinica.Migrations
{
    public partial class Angajat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Serviciu",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Durata",
                table: "Serviciu",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "AngajatID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calificare = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_AngajatID",
                table: "Serviciu",
                column: "AngajatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Angajat_AngajatID",
                table: "Serviciu",
                column: "AngajatID",
                principalTable: "Angajat",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Angajat_AngajatID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "Angajat");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_AngajatID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "AngajatID",
                table: "Serviciu");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Serviciu",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Durata",
                table: "Serviciu",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
