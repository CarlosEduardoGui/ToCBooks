using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToCBooks.App.Migrations
{
    public partial class Atualizacao09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartaoCredito",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    NumeroCartao = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    CodigoSeguranca = table.Column<int>(nullable: false),
                    Bandeira = table.Column<int>(nullable: false),
                    Principal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaoCredito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Senha = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaisModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefoneModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
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
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
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
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Titulo = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    Foto = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Autor = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    Editora = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Edicao = table.Column<int>(nullable: false),
                    ISBN = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Paginas = table.Column<int>(nullable: false),
                    Altura = table.Column<double>(nullable: false),
                    Largura = table.Column<double>(nullable: false),
                    Profundidade = table.Column<double>(nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    PrecificacaoId = table.Column<Guid>(nullable: true),
                    CodigoDeBarras = table.Column<string>(type: "VARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Parametro_PrecificacaoId",
                        column: x => x.PrecificacaoId,
                        principalTable: "Parametro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CidadeModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
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
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    NomeCategoria = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    LivrosModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Livro_LivrosModelId",
                        column: x => x.LivrosModelId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    CidadeId = table.Column<Guid>(nullable: true),
                    TipoLogradouro = table.Column<int>(nullable: false),
                    TipoResidencia = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Principal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoCobranca_CidadeModel_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "CidadeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoEntrega",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    CidadeId = table.Column<Guid>(nullable: true),
                    TipoLogradouro = table.Column<int>(nullable: false),
                    TipoResidencia = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Principal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoEntrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoEntrega_CidadeModel_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "CidadeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    CPF = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    LoginId = table.Column<Guid>(nullable: true),
                    TelefoneId = table.Column<Guid>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    EnderecoCobrancaId = table.Column<Guid>(nullable: true),
                    EnderecoEntregaId = table.Column<Guid>(nullable: true),
                    CartaoCreditoId = table.Column<Guid>(nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false),
                    TipoGenero = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_CartaoCredito_CartaoCreditoId",
                        column: x => x.CartaoCreditoId,
                        principalTable: "CartaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_EnderecoCobranca_EnderecoCobrancaId",
                        column: x => x.EnderecoCobrancaId,
                        principalTable: "EnderecoCobranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_EnderecoEntrega_EnderecoEntregaId",
                        column: x => x.EnderecoEntregaId,
                        principalTable: "EnderecoEntrega",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Login_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Login",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_TelefoneModel_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "TelefoneModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_LivrosModelId",
                table: "Categoria",
                column: "LivrosModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CidadeModel_EstadoId",
                table: "CidadeModel",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CartaoCreditoId",
                table: "Cliente",
                column: "CartaoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoCobrancaId",
                table: "Cliente",
                column: "EnderecoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoEntregaId",
                table: "Cliente",
                column: "EnderecoEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_LoginId",
                table: "Cliente",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_TelefoneId",
                table: "Cliente",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCobranca_CidadeId",
                table: "EnderecoCobranca",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEntrega_CidadeId",
                table: "EnderecoEntrega",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoModel_PaisId",
                table: "EstadoModel",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_PrecificacaoId",
                table: "Livro",
                column: "PrecificacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "CartaoCredito");

            migrationBuilder.DropTable(
                name: "EnderecoCobranca");

            migrationBuilder.DropTable(
                name: "EnderecoEntrega");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "TelefoneModel");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "CidadeModel");

            migrationBuilder.DropTable(
                name: "EstadoModel");

            migrationBuilder.DropTable(
                name: "PaisModel");
        }
    }
}
