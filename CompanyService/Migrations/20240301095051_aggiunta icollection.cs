using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyService.Migrations
{
    /// <inheritdoc />
    public partial class aggiuntaicollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Biglietti_VoloId",
                table: "Biglietti",
                column: "VoloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Biglietti_Voli_VoloId",
                table: "Biglietti",
                column: "VoloId",
                principalTable: "Voli",
                principalColumn: "VoloId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biglietti_Voli_VoloId",
                table: "Biglietti");

            migrationBuilder.DropIndex(
                name: "IX_Biglietti_VoloId",
                table: "Biglietti");
        }
    }
}
