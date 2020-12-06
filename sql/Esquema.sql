USE [master]
GO
/****** Object:  Database [ToCBooks]    Script Date: 06/12/2020 19:11:18 ******/
CREATE DATABASE [ToCBooks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToCBooks', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS2017\MSSQL\DATA\ToCBooks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToCBooks_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS2017\MSSQL\DATA\ToCBooks_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ToCBooks] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToCBooks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToCBooks] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToCBooks] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToCBooks] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToCBooks] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToCBooks] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToCBooks] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToCBooks] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToCBooks] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToCBooks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToCBooks] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToCBooks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToCBooks] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToCBooks] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToCBooks] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToCBooks] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ToCBooks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToCBooks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToCBooks] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToCBooks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToCBooks] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToCBooks] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToCBooks] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToCBooks] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ToCBooks] SET  MULTI_USER 
GO
ALTER DATABASE [ToCBooks] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToCBooks] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToCBooks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToCBooks] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ToCBooks] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ToCBooks] SET QUERY_STORE = OFF
GO
USE [ToCBooks]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartaoCredito]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartaoCredito](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[NumeroCartao] [varchar](max) NULL,
	[Nome] [varchar](max) NULL,
	[CodigoSeguranca] [int] NOT NULL,
	[Bandeira] [int] NOT NULL,
	[DataVencimento] [datetime2](7) NOT NULL,
	[Principal] [bit] NOT NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CartaoCredito] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartaoCreditoPedido]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartaoCreditoPedido](
	[Id] [uniqueidentifier] NOT NULL,
	[CartaoCreditoID] [uniqueidentifier] NOT NULL,
	[PedidoId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CartaoCreditoPedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[NomeCategoria] [varchar](max) NULL,
	[LivrosModelId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CidadeModel]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CidadeModel](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Nome] [varchar](max) NULL,
	[EstadoId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CidadeModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Nome] [varchar](max) NULL,
	[CPF] [varchar](max) NULL,
	[TelefoneId] [uniqueidentifier] NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
	[TipoUsuario] [int] NOT NULL,
	[TipoGenero] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[Credito] [real] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cupom]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cupom](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Nome] [varchar](max) NULL,
	[Desconto] [float] NOT NULL,
 CONSTRAINT [PK_Cupom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnderecoCobranca]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnderecoCobranca](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Numero] [int] NOT NULL,
	[Nome] [varchar](max) NULL,
	[Bairro] [varchar](max) NULL,
	[CEP] [int] NOT NULL,
	[CidadeId] [uniqueidentifier] NULL,
	[TipoLogradouro] [int] NOT NULL,
	[TipoResidencia] [int] NOT NULL,
	[Observacao] [varchar](max) NULL,
	[Principal] [bit] NOT NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EnderecoCobranca] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnderecoEntrega]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnderecoEntrega](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Numero] [int] NOT NULL,
	[Bairro] [varchar](max) NULL,
	[Nome] [varchar](max) NULL,
	[CEP] [int] NOT NULL,
	[CidadeId] [uniqueidentifier] NULL,
	[TipoLogradouro] [int] NOT NULL,
	[TipoResidencia] [int] NOT NULL,
	[Observacao] [varchar](max) NULL,
	[Principal] [bit] NOT NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EnderecoEntrega] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoModel]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoModel](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Nome] [varchar](max) NULL,
	[PaisId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_EstadoModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estoque]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estoque](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[LivroId] [uniqueidentifier] NULL,
	[Qtde] [int] NOT NULL,
 CONSTRAINT [PK_Estoque] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItensPedidos]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItensPedidos](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Qtde] [int] NOT NULL,
	[LivroId] [uniqueidentifier] NULL,
	[PedidoId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ItensPedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livro]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livro](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Titulo] [varchar](max) NULL,
	[Preco] [float] NOT NULL,
	[Foto] [varchar](max) NULL,
	[Descricao] [varchar](max) NULL,
	[Autor] [varchar](max) NULL,
	[Ano] [int] NOT NULL,
	[Editora] [varchar](max) NULL,
	[Edicao] [int] NOT NULL,
	[ISBN] [varchar](max) NULL,
	[Paginas] [int] NOT NULL,
	[Altura] [float] NOT NULL,
	[Largura] [float] NOT NULL,
	[Profundidade] [float] NOT NULL,
	[Peso] [float] NOT NULL,
	[PrecificacaoId] [uniqueidentifier] NULL,
	[CodigoDeBarras] [varchar](max) NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Email] [varchar](max) NULL,
	[Senha] [varchar](max) NULL,
	[TipoUsuario] [int] NOT NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaisModel]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaisModel](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Nome] [varchar](max) NULL,
 CONSTRAINT [PK_PaisModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametro]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametro](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Nome] [varchar](max) NULL,
	[Valor] [float] NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_Parametro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[EnderecoEntregaId] [uniqueidentifier] NULL,
	[ClienteId] [uniqueidentifier] NULL,
	[CupomDescontoId] [uniqueidentifier] NULL,
	[TotalPedido] [float] NOT NULL,
	[DescontoPorCredito] [real] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TelefoneModel]    Script Date: 06/12/2020 19:11:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TelefoneModel](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusAtual] [int] NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[DDD] [int] NOT NULL,
	[Numero] [int] NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_TelefoneModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_CartaoCredito_ClienteId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_CartaoCredito_ClienteId] ON [dbo].[CartaoCredito]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartaoCreditoPedido_CartaoCreditoID]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_CartaoCreditoPedido_CartaoCreditoID] ON [dbo].[CartaoCreditoPedido]
(
	[CartaoCreditoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartaoCreditoPedido_PedidoId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_CartaoCreditoPedido_PedidoId] ON [dbo].[CartaoCreditoPedido]
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categoria_LivrosModelId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_Categoria_LivrosModelId] ON [dbo].[Categoria]
(
	[LivrosModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CidadeModel_EstadoId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_CidadeModel_EstadoId] ON [dbo].[CidadeModel]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cliente_TelefoneId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_Cliente_TelefoneId] ON [dbo].[Cliente]
(
	[TelefoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EnderecoCobranca_CidadeId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_EnderecoCobranca_CidadeId] ON [dbo].[EnderecoCobranca]
(
	[CidadeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EnderecoCobranca_ClienteId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_EnderecoCobranca_ClienteId] ON [dbo].[EnderecoCobranca]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EnderecoEntrega_CidadeId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_EnderecoEntrega_CidadeId] ON [dbo].[EnderecoEntrega]
(
	[CidadeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EnderecoEntrega_ClienteId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_EnderecoEntrega_ClienteId] ON [dbo].[EnderecoEntrega]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoModel_PaisId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoModel_PaisId] ON [dbo].[EstadoModel]
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Estoque_LivroId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_Estoque_LivroId] ON [dbo].[Estoque]
(
	[LivroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItensPedidos_LivroId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_ItensPedidos_LivroId] ON [dbo].[ItensPedidos]
(
	[LivroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItensPedidos_PedidoId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_ItensPedidos_PedidoId] ON [dbo].[ItensPedidos]
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livro_PrecificacaoId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_Livro_PrecificacaoId] ON [dbo].[Livro]
(
	[PrecificacaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Login_ClienteId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Login_ClienteId] ON [dbo].[Login]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pedido_ClienteId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_Pedido_ClienteId] ON [dbo].[Pedido]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pedido_CupomDescontoId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_Pedido_CupomDescontoId] ON [dbo].[Pedido]
(
	[CupomDescontoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pedido_EnderecoEntregaId]    Script Date: 06/12/2020 19:11:18 ******/
CREATE NONCLUSTERED INDEX [IX_Pedido_EnderecoEntregaId] ON [dbo].[Pedido]
(
	[EnderecoEntregaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (CONVERT([real],(0))) FOR [Credito]
GO
ALTER TABLE [dbo].[Pedido] ADD  DEFAULT (CONVERT([real],(0))) FOR [DescontoPorCredito]
GO
ALTER TABLE [dbo].[CartaoCredito]  WITH CHECK ADD  CONSTRAINT [FK_CartaoCredito_Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[CartaoCredito] CHECK CONSTRAINT [FK_CartaoCredito_Cliente_ClienteId]
GO
ALTER TABLE [dbo].[CartaoCreditoPedido]  WITH CHECK ADD  CONSTRAINT [FK_CartaoCreditoPedido_CartaoCredito_CartaoCreditoID] FOREIGN KEY([CartaoCreditoID])
REFERENCES [dbo].[CartaoCredito] ([Id])
GO
ALTER TABLE [dbo].[CartaoCreditoPedido] CHECK CONSTRAINT [FK_CartaoCreditoPedido_CartaoCredito_CartaoCreditoID]
GO
ALTER TABLE [dbo].[CartaoCreditoPedido]  WITH CHECK ADD  CONSTRAINT [FK_CartaoCreditoPedido_Pedido_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[CartaoCreditoPedido] CHECK CONSTRAINT [FK_CartaoCreditoPedido_Pedido_PedidoId]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Livro_LivrosModelId] FOREIGN KEY([LivrosModelId])
REFERENCES [dbo].[Livro] ([Id])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Livro_LivrosModelId]
GO
ALTER TABLE [dbo].[CidadeModel]  WITH CHECK ADD  CONSTRAINT [FK_CidadeModel_EstadoModel_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[EstadoModel] ([Id])
GO
ALTER TABLE [dbo].[CidadeModel] CHECK CONSTRAINT [FK_CidadeModel_EstadoModel_EstadoId]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_TelefoneModel_TelefoneId] FOREIGN KEY([TelefoneId])
REFERENCES [dbo].[TelefoneModel] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_TelefoneModel_TelefoneId]
GO
ALTER TABLE [dbo].[EnderecoCobranca]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoCobranca_CidadeModel_CidadeId] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[CidadeModel] ([Id])
GO
ALTER TABLE [dbo].[EnderecoCobranca] CHECK CONSTRAINT [FK_EnderecoCobranca_CidadeModel_CidadeId]
GO
ALTER TABLE [dbo].[EnderecoCobranca]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoCobranca_Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[EnderecoCobranca] CHECK CONSTRAINT [FK_EnderecoCobranca_Cliente_ClienteId]
GO
ALTER TABLE [dbo].[EnderecoEntrega]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoEntrega_CidadeModel_CidadeId] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[CidadeModel] ([Id])
GO
ALTER TABLE [dbo].[EnderecoEntrega] CHECK CONSTRAINT [FK_EnderecoEntrega_CidadeModel_CidadeId]
GO
ALTER TABLE [dbo].[EnderecoEntrega]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoEntrega_Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[EnderecoEntrega] CHECK CONSTRAINT [FK_EnderecoEntrega_Cliente_ClienteId]
GO
ALTER TABLE [dbo].[EstadoModel]  WITH CHECK ADD  CONSTRAINT [FK_EstadoModel_PaisModel_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[PaisModel] ([Id])
GO
ALTER TABLE [dbo].[EstadoModel] CHECK CONSTRAINT [FK_EstadoModel_PaisModel_PaisId]
GO
ALTER TABLE [dbo].[Estoque]  WITH CHECK ADD  CONSTRAINT [FK_Estoque_Livro_LivroId] FOREIGN KEY([LivroId])
REFERENCES [dbo].[Livro] ([Id])
GO
ALTER TABLE [dbo].[Estoque] CHECK CONSTRAINT [FK_Estoque_Livro_LivroId]
GO
ALTER TABLE [dbo].[ItensPedidos]  WITH CHECK ADD  CONSTRAINT [FK_ItensPedidos_Livro_LivroId] FOREIGN KEY([LivroId])
REFERENCES [dbo].[Livro] ([Id])
GO
ALTER TABLE [dbo].[ItensPedidos] CHECK CONSTRAINT [FK_ItensPedidos_Livro_LivroId]
GO
ALTER TABLE [dbo].[ItensPedidos]  WITH CHECK ADD  CONSTRAINT [FK_ItensPedidos_Pedido_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[ItensPedidos] CHECK CONSTRAINT [FK_ItensPedidos_Pedido_PedidoId]
GO
ALTER TABLE [dbo].[Livro]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Parametro_PrecificacaoId] FOREIGN KEY([PrecificacaoId])
REFERENCES [dbo].[Parametro] ([Id])
GO
ALTER TABLE [dbo].[Livro] CHECK CONSTRAINT [FK_Livro_Parametro_PrecificacaoId]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Cliente_ClienteId]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente_ClienteId]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cupom_CupomDescontoId] FOREIGN KEY([CupomDescontoId])
REFERENCES [dbo].[Cupom] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cupom_CupomDescontoId]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_EnderecoEntrega_EnderecoEntregaId] FOREIGN KEY([EnderecoEntregaId])
REFERENCES [dbo].[EnderecoEntrega] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_EnderecoEntrega_EnderecoEntregaId]
GO
USE [master]
GO
ALTER DATABASE [ToCBooks] SET  READ_WRITE 
GO
