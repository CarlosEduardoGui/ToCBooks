﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToCBooks.App.Data.Context;

namespace ToCBooks.App.Migrations
{
    [DbContext(typeof(ToCBooksContext))]
    partial class ToCBooksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToCBooks.App.Business.Models.CartaoCreditoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bandeira");

                    b.Property<Guid>("ClienteId");

                    b.Property<int>("CodigoSeguranca");

                    b.Property<DateTime>("DataVencimento");

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("NumeroCartao")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<bool>("Principal");

                    b.Property<int>("StatusAtual");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("CartaoCredito");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<Guid?>("LivrosModelId");

                    b.Property<string>("NomeCategoria")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("StatusAtual");

                    b.HasKey("Id");

                    b.HasIndex("LivrosModelId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.CidadeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("EstadoId");

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("StatusAtual");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("CidadeModel");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.ClienteModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("CPF")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("StatusAtual");

                    b.Property<Guid?>("TelefoneId");

                    b.Property<int>("TipoGenero");

                    b.Property<int>("TipoUsuario");

                    b.HasKey("Id");

                    b.HasIndex("TelefoneId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.EnderecoCobrancaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("CEP");

                    b.Property<Guid?>("CidadeId");

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("Numero");

                    b.Property<string>("Observacao")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<bool>("Principal");

                    b.Property<int>("StatusAtual");

                    b.Property<int>("TipoLogradouro");

                    b.Property<int>("TipoResidencia");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteId");

                    b.ToTable("EnderecoCobranca");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.EnderecoEntregaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("CEP");

                    b.Property<Guid?>("CidadeId");

                    b.Property<Guid?>("ClienteModelId");

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("Numero");

                    b.Property<string>("Observacao")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<bool>("Principal");

                    b.Property<int>("StatusAtual");

                    b.Property<int>("TipoLogradouro");

                    b.Property<int>("TipoResidencia");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteModelId");

                    b.ToTable("EnderecoEntrega");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.EstadoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<Guid?>("PaisId");

                    b.Property<int>("StatusAtual");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("EstadoModel");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.LivrosModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Altura");

                    b.Property<int>("Ano");

                    b.Property<string>("Autor")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("CodigoDeBarras")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("Edicao");

                    b.Property<string>("Editora")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Foto")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("ISBN")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<double>("Largura");

                    b.Property<int>("Paginas");

                    b.Property<double>("Peso");

                    b.Property<Guid?>("PrecificacaoId");

                    b.Property<double>("Preco");

                    b.Property<double>("Profundidade");

                    b.Property<int>("StatusAtual");

                    b.Property<string>("Titulo")
                        .HasColumnType("VARCHAR(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("PrecificacaoId");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.LoginModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Senha")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("StatusAtual");

                    b.Property<int>("TipoUsuario");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Login");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.PaisModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("StatusAtual");

                    b.HasKey("Id");

                    b.ToTable("PaisModel");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.Parametro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("StatusAtual");

                    b.Property<int>("Tipo");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Parametro");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.TelefoneModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DDD");

                    b.Property<string>("Justificativa")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int>("Numero");

                    b.Property<int>("StatusAtual");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("TelefoneModel");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.CartaoCreditoModel", b =>
                {
                    b.HasOne("ToCBooks.App.Business.Models.ClienteModel", "Cliente")
                        .WithMany("CartaoCredito")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.Categoria", b =>
                {
                    b.HasOne("ToCBooks.App.Business.Models.LivrosModel")
                        .WithMany("Categorias")
                        .HasForeignKey("LivrosModelId");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.CidadeModel", b =>
                {
                    b.HasOne("ToCBooks.App.Business.Models.EstadoModel", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.ClienteModel", b =>
                {
                    b.HasOne("ToCBooks.App.Business.Models.TelefoneModel", "Telefone")
                        .WithMany()
                        .HasForeignKey("TelefoneId");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.EnderecoCobrancaModel", b =>
                {
                    b.HasOne("ToCBooks.App.Business.Models.CidadeModel", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("ToCBooks.App.Business.Models.ClienteModel", "Cliente")
                        .WithMany("EnderecoCobranca")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.EnderecoEntregaModel", b =>
                {
                    b.HasOne("ToCBooks.App.Business.Models.CidadeModel", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("ToCBooks.App.Business.Models.ClienteModel")
                        .WithMany("EnderecoEntrega")
                        .HasForeignKey("ClienteModelId");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.EstadoModel", b =>
                {
                    b.HasOne("ToCBooks.App.Business.Models.PaisModel", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.LivrosModel", b =>
                {
                    b.HasOne("ToCBooks.App.Business.Models.Parametro", "Precificacao")
                        .WithMany()
                        .HasForeignKey("PrecificacaoId");
                });

            modelBuilder.Entity("ToCBooks.App.Business.Models.LoginModel", b =>
                {
                    b.HasOne("ToCBooks.App.Business.Models.ClienteModel", "Cliente")
                        .WithOne("Login")
                        .HasForeignKey("ToCBooks.App.Business.Models.LoginModel", "ClienteId");
                });
#pragma warning restore 612, 618
        }
    }
}
