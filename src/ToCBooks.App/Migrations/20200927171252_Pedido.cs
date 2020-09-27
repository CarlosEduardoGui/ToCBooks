using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Pedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PedidoModelId",
                table: "Estoque",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PedidoModelId",
                table: "CartaoCredito",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    EnderecoEntregaId = table.Column<Guid>(nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true),
                    CupomDescontoId = table.Column<Guid>(nullable: true),
                    TotalPedido = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Cupom_CupomDescontoId",
                        column: x => x.CupomDescontoId,
                        principalTable: "Cupom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_EnderecoEntrega_EnderecoEntregaId",
                        column: x => x.EnderecoEntregaId,
                        principalTable: "EnderecoEntrega",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_PedidoModelId",
                table: "Estoque",
                column: "PedidoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCredito_PedidoModelId",
                table: "CartaoCredito",
                column: "PedidoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CupomDescontoId",
                table: "Pedido",
                column: "CupomDescontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EnderecoEntregaId",
                table: "Pedido",
                column: "EnderecoEntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartaoCredito_Pedido_PedidoModelId",
                table: "CartaoCredito",
                column: "PedidoModelId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Pedido_PedidoModelId",
                table: "Estoque",
                column: "PedidoModelId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartaoCredito_Pedido_PedidoModelId",
                table: "CartaoCredito");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Pedido_PedidoModelId",
                table: "Estoque");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_PedidoModelId",
                table: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_CartaoCredito_PedidoModelId",
                table: "CartaoCredito");

            migrationBuilder.DropColumn(
                name: "PedidoModelId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "PedidoModelId",
                table: "CartaoCredito");
        }
    }
}
