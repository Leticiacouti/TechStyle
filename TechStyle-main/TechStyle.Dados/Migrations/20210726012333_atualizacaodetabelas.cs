using Microsoft.EntityFrameworkCore.Migrations;

namespace TechStyle.Dados.Migrations
{
    public partial class atualizacaodetabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produto_ProdutoId",
                table: "Estoque");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Estoque",
                newName: "IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                newName: "IX_Estoque_IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produto_IdProduto",
                table: "Estoque",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produto_IdProduto",
                table: "Estoque");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "Estoque",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_IdProduto",
                table: "Estoque",
                newName: "IX_Estoque_ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produto_ProdutoId",
                table: "Estoque",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
