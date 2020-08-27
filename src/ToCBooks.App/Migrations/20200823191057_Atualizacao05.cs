using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Atualizacao05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Altura",
                table: "Livros",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Livros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Livros",
                type: "VARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoDeBarras",
                table: "Livros",
                type: "VARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Edicao",
                table: "Livros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Editora",
                table: "Livros",
                type: "VARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Livros",
                type: "VARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Largura",
                table: "Livros",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Paginas",
                table: "Livros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "Livros",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "PrecificacaoId",
                table: "Livros",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Profundidade",
                table: "Livros",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    LivrosModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Livros_LivrosModelId",
                        column: x => x.LivrosModelId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_PrecificacaoId",
                table: "Livros",
                column: "PrecificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_LivrosModelId",
                table: "Categoria",
                column: "LivrosModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Parametro_PrecificacaoId",
                table: "Livros",
                column: "PrecificacaoId",
                principalTable: "Parametro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Parametro_PrecificacaoId",
                table: "Livros");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropIndex(
                name: "IX_Livros_PrecificacaoId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "CodigoDeBarras",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Edicao",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Editora",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Largura",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Paginas",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "PrecificacaoId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Profundidade",
                table: "Livros");
        }
    }
}
