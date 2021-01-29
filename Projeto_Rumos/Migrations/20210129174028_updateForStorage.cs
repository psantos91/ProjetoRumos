using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Rumos.Migrations
{
    public partial class updateForStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encomendas_CarrinhoCompras_IdCarrinhoCompra",
                table: "Encomendas");

            migrationBuilder.DropIndex(
                name: "IX_Encomendas_IdCarrinhoCompra",
                table: "Encomendas");

            migrationBuilder.DropColumn(
                name: "IdCarrinhoCompra",
                table: "Encomendas");

            migrationBuilder.AddColumn<int>(
                name: "EncomendaId",
                table: "CarrinhoCompras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompras_EncomendaId",
                table: "CarrinhoCompras",
                column: "EncomendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompras_Encomendas_EncomendaId",
                table: "CarrinhoCompras",
                column: "EncomendaId",
                principalTable: "Encomendas",
                principalColumn: "EncomendaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompras_Encomendas_EncomendaId",
                table: "CarrinhoCompras");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoCompras_EncomendaId",
                table: "CarrinhoCompras");

            migrationBuilder.DropColumn(
                name: "EncomendaId",
                table: "CarrinhoCompras");

            migrationBuilder.AddColumn<int>(
                name: "IdCarrinhoCompra",
                table: "Encomendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Encomendas_IdCarrinhoCompra",
                table: "Encomendas",
                column: "IdCarrinhoCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_Encomendas_CarrinhoCompras_IdCarrinhoCompra",
                table: "Encomendas",
                column: "IdCarrinhoCompra",
                principalTable: "CarrinhoCompras",
                principalColumn: "CarrinhoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
