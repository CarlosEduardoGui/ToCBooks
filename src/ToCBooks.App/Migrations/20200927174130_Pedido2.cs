using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Pedido2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartaoCredito_Pedido_PedidoModelId",
                table: "CartaoCredito");

            migrationBuilder.DropIndex(
                name: "IX_CartaoCredito_PedidoModelId",
                table: "CartaoCredito");

            migrationBuilder.DropColumn(
                name: "PedidoModelId",
                table: "CartaoCredito");

            migrationBuilder.CreateTable(
                name: "CartaoCreditoPedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CartaoCreditoID = table.Column<Guid>(nullable: false),
                    PedidoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaoCreditoPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartaoCreditoPedido_CartaoCredito_CartaoCreditoID",
                        column: x => x.CartaoCreditoID,
                        principalTable: "CartaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartaoCreditoPedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCreditoPedido_CartaoCreditoID",
                table: "CartaoCreditoPedido",
                column: "CartaoCreditoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCreditoPedido_PedidoId",
                table: "CartaoCreditoPedido",
                column: "PedidoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartaoCreditoPedido");

            migrationBuilder.AddColumn<Guid>(
                name: "PedidoModelId",
                table: "CartaoCredito",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCredito_PedidoModelId",
                table: "CartaoCredito",
                column: "PedidoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartaoCredito_Pedido_PedidoModelId",
                table: "CartaoCredito",
                column: "PedidoModelId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
