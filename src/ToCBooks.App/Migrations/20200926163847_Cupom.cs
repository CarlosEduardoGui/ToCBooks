using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Cupom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cupom",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Desconto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupom", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cupom");
        }
    }
}
