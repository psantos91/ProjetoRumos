using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Rumos.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Imagens_ImagemProdutoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ImagemProdutoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdImagem",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ImagemProdutoId",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "Url",
                value: "https://ac2020storage.blob.core.windows.net/joaomachado/banana1.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "Url",
                value: "https://ac2020storage.blob.core.windows.net/joaomachado/clementina.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "Url",
                value: "https://ac2020storage.blob.core.windows.net/joaomachado/fuji.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 4,
                column: "Url",
                value: "https://ac2020storage.blob.core.windows.net/joaomachado/kiwi.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 5,
                column: "Url",
                value: "https://ac2020storage.blob.core.windows.net/joaomachado/limao-siciliano.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 6,
                column: "Url",
                value: "https://ac2020storage.blob.core.windows.net/joaomachado/melao.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 7,
                column: "Url",
                value: "https://ac2020storage.blob.core.windows.net/joaomachado/peras.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 8,
                column: "Url",
                value: "https://ac2020storage.blob.core.windows.net/joaomachado/uvas.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "IdImagem",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImagemProdutoId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dados = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ImagemProdutoId",
                table: "Produtos",
                column: "ImagemProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Imagens_ImagemProdutoId",
                table: "Produtos",
                column: "ImagemProdutoId",
                principalTable: "Imagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
