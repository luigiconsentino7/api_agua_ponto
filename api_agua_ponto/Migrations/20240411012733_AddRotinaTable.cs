using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_agua_ponto.Migrations
{
    /// <inheritdoc />
    public partial class AddRotinaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rotina_dorme",
                table: "UsuarioDb",
                newName: "RotinaDorme");

            migrationBuilder.RenameColumn(
                name: "Rotina_acorda",
                table: "UsuarioDb",
                newName: "RotinaAcorda");

            migrationBuilder.RenameColumn(
                name: "Media_agua",
                table: "UsuarioDb",
                newName: "MediaAgua");

            migrationBuilder.RenameColumn(
                name: "Data_nascimento",
                table: "UsuarioDb",
                newName: "DataNascimento");

            migrationBuilder.CreateTable(
                name: "RotinaDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiraIngestao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaIngestao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MlIngerido = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotinaDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotinaDb_UsuarioDb_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "UsuarioDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RotinaDb_UsuarioId",
                table: "RotinaDb",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RotinaDb");

            migrationBuilder.RenameColumn(
                name: "RotinaDorme",
                table: "UsuarioDb",
                newName: "Rotina_dorme");

            migrationBuilder.RenameColumn(
                name: "RotinaAcorda",
                table: "UsuarioDb",
                newName: "Rotina_acorda");

            migrationBuilder.RenameColumn(
                name: "MediaAgua",
                table: "UsuarioDb",
                newName: "Media_agua");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "UsuarioDb",
                newName: "Data_nascimento");
        }
    }
}
