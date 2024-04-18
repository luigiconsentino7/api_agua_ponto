using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_agua_ponto.Migrations
{
    /// <inheritdoc />
    public partial class AddDataNascimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "UsuarioDb");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_nascimento",
                table: "UsuarioDb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "UsuarioDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_nascimento",
                table: "UsuarioDb");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "UsuarioDb");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "UsuarioDb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
