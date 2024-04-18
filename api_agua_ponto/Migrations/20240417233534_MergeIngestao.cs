using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_agua_ponto.Migrations
{
    /// <inheritdoc />
    public partial class MergeIngestao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimeiraIngestao",
                table: "RotinaDb");

            migrationBuilder.RenameColumn(
                name: "UltimaIngestao",
                table: "RotinaDb",
                newName: "Ingestao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ingestao",
                table: "RotinaDb",
                newName: "UltimaIngestao");

            migrationBuilder.AddColumn<DateTime>(
                name: "PrimeiraIngestao",
                table: "RotinaDb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
