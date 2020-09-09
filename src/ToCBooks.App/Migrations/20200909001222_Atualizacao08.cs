using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Atualizacao08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "Parametro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "PaisModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "Livros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "EstadoModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "EnderecoEntregaModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "EnderecoCobrancaModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "ClienteModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "CidadeModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "Categoria",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "PaisModel");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "EstadoModel");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "EnderecoEntregaModel");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "EnderecoCobrancaModel");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "ClienteModel");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "CidadeModel");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "Categoria");
        }
    }
}
