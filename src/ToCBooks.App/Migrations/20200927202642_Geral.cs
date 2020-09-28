﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ToCBooks.App.Migrations
{
    public partial class Geral : Migration
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

            migrationBuilder.CreateTable(
                name: "PaisModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
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
                    DataCadastro = table.Column<DateTime>(nullable: false),
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
                    DataCadastro = table.Column<DateTime>(nullable: false),
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
                    DataCadastro = table.Column<DateTime>(nullable: false),
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
                    DataCadastro = table.Column<DateTime>(nullable: false),
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
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    CPF = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    TelefoneId = table.Column<Guid>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false),
                    TipoGenero = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_TelefoneModel_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "TelefoneModel",
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
                    DataCadastro = table.Column<DateTime>(nullable: false),
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
                    DataCadastro = table.Column<DateTime>(nullable: false),
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
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    LivroId = table.Column<Guid>(nullable: true),
                    Qtde = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartaoCredito",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    NumeroCartao = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    CodigoSeguranca = table.Column<int>(nullable: false),
                    Bandeira = table.Column<int>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Principal = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaoCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartaoCredito_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusAtual = table.Column<int>(nullable: false),
                    Justificativa = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Senha = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Login_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
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
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    CidadeId = table.Column<Guid>(nullable: true),
                    TipoLogradouro = table.Column<int>(nullable: false),
                    TipoResidencia = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Principal = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_EnderecoCobranca_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
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
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    CidadeId = table.Column<Guid>(nullable: true),
                    TipoLogradouro = table.Column<int>(nullable: false),
                    TipoResidencia = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Principal = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_EnderecoEntrega_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_CartaoCredito_ClienteId",
                table: "CartaoCredito",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCreditoPedido_CartaoCreditoID",
                table: "CartaoCreditoPedido",
                column: "CartaoCreditoID");

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCreditoPedido_PedidoId",
                table: "CartaoCreditoPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_LivrosModelId",
                table: "Categoria",
                column: "LivrosModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CidadeModel_EstadoId",
                table: "CidadeModel",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_TelefoneId",
                table: "Cliente",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCobranca_CidadeId",
                table: "EnderecoCobranca",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCobranca_ClienteId",
                table: "EnderecoCobranca",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEntrega_CidadeId",
                table: "EnderecoEntrega",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEntrega_ClienteId",
                table: "EnderecoEntrega",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoModel_PaisId",
                table: "EstadoModel",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_LivroId",
                table: "Estoque",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_LivroId",
                table: "ItensPedidos",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_PrecificacaoId",
                table: "Livro",
                column: "PrecificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_ClienteId",
                table: "Login",
                column: "ClienteId",
                unique: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartaoCreditoPedido");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "EnderecoCobranca");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "CartaoCredito");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "Cupom");

            migrationBuilder.DropTable(
                name: "EnderecoEntrega");

            migrationBuilder.DropTable(
                name: "CidadeModel");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EstadoModel");

            migrationBuilder.DropTable(
                name: "TelefoneModel");

            migrationBuilder.DropTable(
                name: "PaisModel");
        }
    }
}