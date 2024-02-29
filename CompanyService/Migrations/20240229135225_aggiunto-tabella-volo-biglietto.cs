using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyService.Migrations
{
    /// <inheritdoc />
    public partial class aggiuntotabellavolobiglietto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biglietti",
                columns: table => new
                {
                    BigliettoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoloId = table.Column<long>(type: "bigint", nullable: false),
                    NumeroPostiRichiesti = table.Column<int>(type: "int", nullable: false),
                    ImportoTotale = table.Column<double>(type: "float", nullable: false),
                    DataAcquisto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biglietti", x => x.BigliettoId);
                });

            migrationBuilder.CreateTable(
                name: "Voli",
                columns: table => new
                {
                    VoloId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AereoId = table.Column<long>(type: "bigint", nullable: false),
                    PostiResidui = table.Column<int>(type: "int", nullable: false),
                    CostoPosto = table.Column<double>(type: "float", nullable: false),
                    Partenza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destinazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrarioPartenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrarioDestinazione = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voli", x => x.VoloId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biglietti");

            migrationBuilder.DropTable(
                name: "Voli");
        }
    }
}
