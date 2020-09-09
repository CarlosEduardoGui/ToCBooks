using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Atualizacao07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Parametros_PrecificacaoId",
                table: "Livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parametros",
                table: "Parametros");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "StatusAtual",
                table: "Parametros");

            migrationBuilder.RenameTable(
                name: "Parametros",
                newName: "Parametro");

            migrationBuilder.AddColumn<string>(
                name: "Justificativa",
                table: "Livros",
                type: "VARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Justificativa",
                table: "Categoria",
                type: "VARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeCategoria",
                table: "Categoria",
                type: "VARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Justificativa",
                table: "Parametro",
                type: "VARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parametro",
                table: "Parametro",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PaisModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefoneModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DDD = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefoneModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    PaisId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadoModel_PaisModel_PaisId",
                        column: x => x.PaisId,
                        principalTable: "PaisModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CidadeModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    EstadoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadeModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CidadeModel_EstadoModel_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoCobrancaModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    CidadeId = table.Column<Guid>(nullable: true),
                    TipoLogradouro = table.Column<int>(nullable: false),
                    TipoResidencia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoCobrancaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoCobrancaModel_CidadeModel_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "CidadeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoEntregaModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    CidadeId = table.Column<Guid>(nullable: true),
                    TipoLogradouro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoEntregaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoEntregaModel_CidadeModel_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "CidadeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    TelefoneId = table.Column<int>(nullable: true),
                    EnderecoCobrancaId = table.Column<Guid>(nullable: true),
                    EnderecoEntregaId = table.Column<Guid>(nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false),
                    TipoGenero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteModel_EnderecoCobrancaModel_EnderecoCobrancaId",
                        column: x => x.EnderecoCobrancaId,
                        principalTable: "EnderecoCobrancaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteModel_EnderecoEntregaModel_EnderecoEntregaId",
                        column: x => x.EnderecoEntregaId,
                        principalTable: "EnderecoEntregaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteModel_TelefoneModel_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "TelefoneModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CidadeModel_EstadoId",
                table: "CidadeModel",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteModel_EnderecoCobrancaId",
                table: "ClienteModel",
                column: "EnderecoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteModel_EnderecoEntregaId",
                table: "ClienteModel",
                column: "EnderecoEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteModel_TelefoneId",
                table: "ClienteModel",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCobrancaModel_CidadeId",
                table: "EnderecoCobrancaModel",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEntregaModel_CidadeId",
                table: "EnderecoEntregaModel",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoModel_PaisId",
                table: "EstadoModel",
                column: "PaisId");

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
                name: "ClienteModel");

            migrationBuilder.DropTable(
                name: "EnderecoCobrancaModel");

            migrationBuilder.DropTable(
                name: "EnderecoEntregaModel");

            migrationBuilder.DropTable(
                name: "TelefoneModel");

            migrationBuilder.DropTable(
                name: "CidadeModel");

            migrationBuilder.DropTable(
                name: "EstadoModel");

            migrationBuilder.DropTable(
                name: "PaisModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parametro",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Justificativa",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Justificativa",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "NomeCategoria",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "Justificativa",
                table: "Parametro");

            migrationBuilder.RenameTable(
                name: "Parametro",
                newName: "Parametros");

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "Livros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "Categoria",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusAtual",
                table: "Parametros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parametros",
                table: "Parametros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Parametros_PrecificacaoId",
                table: "Livros",
                column: "PrecificacaoId",
                principalTable: "Parametros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
