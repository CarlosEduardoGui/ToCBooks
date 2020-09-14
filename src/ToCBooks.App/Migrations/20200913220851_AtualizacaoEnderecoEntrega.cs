using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class AtualizacaoEnderecoEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoEntrega_Cliente_ClienteModelId",
                table: "EnderecoEntrega");

            migrationBuilder.DropIndex(
                name: "IX_EnderecoEntrega_ClienteModelId",
                table: "EnderecoEntrega");

            migrationBuilder.DropColumn(
                name: "ClienteModelId",
                table: "EnderecoEntrega");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "EnderecoEntrega",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEntrega_ClienteId",
                table: "EnderecoEntrega",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoEntrega_Cliente_ClienteId",
                table: "EnderecoEntrega",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoEntrega_Cliente_ClienteId",
                table: "EnderecoEntrega");

            migrationBuilder.DropIndex(
                name: "IX_EnderecoEntrega_ClienteId",
                table: "EnderecoEntrega");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "EnderecoEntrega");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteModelId",
                table: "EnderecoEntrega",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEntrega_ClienteModelId",
                table: "EnderecoEntrega",
                column: "ClienteModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoEntrega_Cliente_ClienteModelId",
                table: "EnderecoEntrega",
                column: "ClienteModelId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
