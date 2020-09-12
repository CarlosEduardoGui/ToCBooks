using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Atualizacao02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_Cliente_ClienteFK",
                table: "Login");

            migrationBuilder.RenameColumn(
                name: "ClienteFK",
                table: "Login",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Login_ClienteFK",
                table: "Login",
                newName: "IX_Login_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Cliente_ClienteId",
                table: "Login",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_Cliente_ClienteId",
                table: "Login");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Login",
                newName: "ClienteFK");

            migrationBuilder.RenameIndex(
                name: "IX_Login_ClienteId",
                table: "Login",
                newName: "IX_Login_ClienteFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Cliente_ClienteFK",
                table: "Login",
                column: "ClienteFK",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
