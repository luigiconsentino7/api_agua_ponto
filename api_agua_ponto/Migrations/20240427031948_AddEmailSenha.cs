using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_agua_ponto.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UsuarioDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "UsuarioDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UsuarioDb");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "UsuarioDb");
        }
    }
}
