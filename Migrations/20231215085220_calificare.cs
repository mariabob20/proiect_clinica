using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_clinica.Migrations
{
    public partial class calificare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calificare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalificareTip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AngajatCalificare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AngajatID = table.Column<int>(type: "int", nullable: false),
                    CalificareID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AngajatCalificare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AngajatCalificare_Angajat_AngajatID",
                        column: x => x.AngajatID,
                        principalTable: "Angajat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AngajatCalificare_Calificare_CalificareID",
                        column: x => x.CalificareID,
                        principalTable: "Calificare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AngajatCalificare_AngajatID",
                table: "AngajatCalificare",
                column: "AngajatID");

            migrationBuilder.CreateIndex(
                name: "IX_AngajatCalificare_CalificareID",
                table: "AngajatCalificare",
                column: "CalificareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AngajatCalificare");

            migrationBuilder.DropTable(
                name: "Calificare");
        }
    }
}
