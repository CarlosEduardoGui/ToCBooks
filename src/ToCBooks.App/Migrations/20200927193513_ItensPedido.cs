using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class ItensPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Qtde = table.Column<int>(nullable: false),
                    LivroId = table.Column<Guid>(nullable: true),
                    PedidoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_LivroId",
                table: "ItensPedidos",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedidos");
        }
    }
}
