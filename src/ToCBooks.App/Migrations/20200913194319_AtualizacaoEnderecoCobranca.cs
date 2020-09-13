using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class AtualizacaoEnderecoCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoCobranca_Cliente_ClienteModelId",
                table: "EnderecoCobranca");

            migrationBuilder.DropIndex(
                name: "IX_EnderecoCobranca_ClienteModelId",
                table: "EnderecoCobranca");

            migrationBuilder.DropColumn(
                name: "ClienteModelId",
                table: "EnderecoCobranca");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "EnderecoCobranca",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCobranca_ClienteId",
                table: "EnderecoCobranca",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoCobranca_Cliente_ClienteId",
                table: "EnderecoCobranca",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoCobranca_Cliente_ClienteId",
                table: "EnderecoCobranca");

            migrationBuilder.DropIndex(
                name: "IX_EnderecoCobranca_ClienteId",
                table: "EnderecoCobranca");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "EnderecoCobranca");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteModelId",
                table: "EnderecoCobranca",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCobranca_ClienteModelId",
                table: "EnderecoCobranca",
                column: "ClienteModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoCobranca_Cliente_ClienteModelId",
                table: "EnderecoCobranca",
                column: "ClienteModelId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
