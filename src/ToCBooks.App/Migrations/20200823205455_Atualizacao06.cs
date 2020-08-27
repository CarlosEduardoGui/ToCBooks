using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Atualizacao06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Parametro_PrecificacaoId",
                table: "Livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parametro",
                table: "Parametro");

            migrationBuilder.RenameTable(
                name: "Parametro",
                newName: "Parametros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parametros",
                table: "Parametros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Parametros_PrecificacaoId",
                table: "Livros",
                column: "PrecificacaoId",
                principalTable: "Parametros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Parametros_PrecificacaoId",
                table: "Livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parametros",
                table: "Parametros");

            migrationBuilder.RenameTable(
                name: "Parametros",
                newName: "Parametro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parametro",
                table: "Parametro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Parametro_PrecificacaoId",
                table: "Livros",
                column: "PrecificacaoId",
                principalTable: "Parametro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
