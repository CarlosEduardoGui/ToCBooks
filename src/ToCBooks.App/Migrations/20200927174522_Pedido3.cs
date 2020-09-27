using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Pedido3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartaoCreditoPedido_CartaoCreditoID",
                table: "CartaoCreditoPedido");

            migrationBuilder.DropIndex(
                name: "IX_CartaoCreditoPedido_PedidoId",
                table: "CartaoCreditoPedido");

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCreditoPedido_CartaoCreditoID",
                table: "CartaoCreditoPedido",
                column: "CartaoCreditoID");

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCreditoPedido_PedidoId",
                table: "CartaoCreditoPedido",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartaoCreditoPedido_CartaoCreditoID",
                table: "CartaoCreditoPedido");

            migrationBuilder.DropIndex(
                name: "IX_CartaoCreditoPedido_PedidoId",
                table: "CartaoCreditoPedido");

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
    }
}
