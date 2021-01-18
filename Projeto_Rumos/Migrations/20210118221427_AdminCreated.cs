using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Rumos.Migrations
{
    public partial class AdminCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Email", "FuncaoEmpregado", "Nome", "NumeroDeTrabalhador", "Password" },
                values: new object[] { 1, "admin@gmail.com", "Administrador", "Admin", 1, "admin123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
