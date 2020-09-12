IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Livros] (
    [Id] uniqueidentifier NOT NULL,
    [Titulo] varchar(8) NOT NULL,
    [Preco] varchar(50) NOT NULL,
    [Foto] varchar(250) NULL,
    [Descricao] varchar(200) NOT NULL,
    CONSTRAINT [PK_Livros] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200822172226_Initial', N'2.2.6-servicing-10079');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Livros]') AND [c].[name] = N'Foto');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Livros] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Livros] DROP COLUMN [Foto];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Livros]') AND [c].[name] = N'Titulo');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Livros] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Livros] ALTER COLUMN [Titulo] varchar(200) NOT NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Livros]') AND [c].[name] = N'Preco');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Livros] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Livros] ALTER COLUMN [Preco] varchar(200) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200822174512_Atualizacao', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Livros] ADD [Foto] VARCHAR(MAX) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200823142117_Atualizacao02', N'2.2.6-servicing-10079');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200823175419_Atualizacao03', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Livros] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200823180153_Atualizacao04', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Livros] ADD [Altura] float NOT NULL DEFAULT 0.0E0;

GO

ALTER TABLE [Livros] ADD [Ano] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Livros] ADD [Autor] VARCHAR(MAX) NULL;

GO

ALTER TABLE [Livros] ADD [CodigoDeBarras] VARCHAR(MAX) NULL;

GO

ALTER TABLE [Livros] ADD [Edicao] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Livros] ADD [Editora] VARCHAR(MAX) NULL;

GO

ALTER TABLE [Livros] ADD [ISBN] VARCHAR(MAX) NULL;

GO

ALTER TABLE [Livros] ADD [Largura] float NOT NULL DEFAULT 0.0E0;

GO

ALTER TABLE [Livros] ADD [Paginas] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Livros] ADD [Peso] float NOT NULL DEFAULT 0.0E0;

GO

ALTER TABLE [Livros] ADD [PrecificacaoId] uniqueidentifier NULL;

GO

ALTER TABLE [Livros] ADD [Profundidade] float NOT NULL DEFAULT 0.0E0;

GO

CREATE TABLE [Categoria] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [LivrosModelId] uniqueidentifier NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Categoria_Livros_LivrosModelId] FOREIGN KEY ([LivrosModelId]) REFERENCES [Livros] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Parametro] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Nome] VARCHAR(MAX) NULL,
    [Valor] float NOT NULL,
    [Tipo] int NOT NULL,
    CONSTRAINT [PK_Parametro] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Livros_PrecificacaoId] ON [Livros] ([PrecificacaoId]);

GO

CREATE INDEX [IX_Categoria_LivrosModelId] ON [Categoria] ([LivrosModelId]);

GO

ALTER TABLE [Livros] ADD CONSTRAINT [FK_Livros_Parametro_PrecificacaoId] FOREIGN KEY ([PrecificacaoId]) REFERENCES [Parametro] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200823191057_Atualizacao05', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Livros] DROP CONSTRAINT [FK_Livros_Parametro_PrecificacaoId];

GO

ALTER TABLE [Parametro] DROP CONSTRAINT [PK_Parametro];

GO

EXEC sp_rename N'[Parametro]', N'Parametros';

GO

ALTER TABLE [Parametros] ADD CONSTRAINT [PK_Parametros] PRIMARY KEY ([Id]);

GO

ALTER TABLE [Livros] ADD CONSTRAINT [FK_Livros_Parametros_PrecificacaoId] FOREIGN KEY ([PrecificacaoId]) REFERENCES [Parametros] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200823205455_Atualizacao06', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Livros] DROP CONSTRAINT [FK_Livros_Parametros_PrecificacaoId];

GO

ALTER TABLE [Parametros] DROP CONSTRAINT [PK_Parametros];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Livros]') AND [c].[name] = N'StatusAtual');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Livros] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Livros] DROP COLUMN [StatusAtual];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categoria]') AND [c].[name] = N'StatusAtual');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Categoria] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Categoria] DROP COLUMN [StatusAtual];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Parametros]') AND [c].[name] = N'StatusAtual');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Parametros] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Parametros] DROP COLUMN [StatusAtual];

GO

EXEC sp_rename N'[Parametros]', N'Parametro';

GO

ALTER TABLE [Livros] ADD [Justificativa] VARCHAR(MAX) NULL;

GO

ALTER TABLE [Categoria] ADD [Justificativa] VARCHAR(MAX) NULL;

GO

ALTER TABLE [Categoria] ADD [NomeCategoria] VARCHAR(MAX) NULL;

GO

ALTER TABLE [Parametro] ADD [Justificativa] VARCHAR(MAX) NULL;

GO

ALTER TABLE [Parametro] ADD CONSTRAINT [PK_Parametro] PRIMARY KEY ([Id]);

GO

CREATE TABLE [PaisModel] (
    [Id] uniqueidentifier NOT NULL,
    [Justificativa] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_PaisModel] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TelefoneModel] (
    [Id] int NOT NULL IDENTITY,
    [DDD] int NOT NULL,
    [Numero] int NOT NULL,
    [Tipo] int NOT NULL,
    CONSTRAINT [PK_TelefoneModel] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [EstadoModel] (
    [Id] uniqueidentifier NOT NULL,
    [Justificativa] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [PaisId] uniqueidentifier NULL,
    CONSTRAINT [PK_EstadoModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EstadoModel_PaisModel_PaisId] FOREIGN KEY ([PaisId]) REFERENCES [PaisModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [CidadeModel] (
    [Id] uniqueidentifier NOT NULL,
    [Justificativa] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [EstadoId] uniqueidentifier NULL,
    CONSTRAINT [PK_CidadeModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CidadeModel_EstadoModel_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [EstadoModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EnderecoCobrancaModel] (
    [Id] uniqueidentifier NOT NULL,
    [Justificativa] nvarchar(max) NULL,
    [Numero] int NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Bairro] nvarchar(max) NULL,
    [CEP] int NOT NULL,
    [CidadeId] uniqueidentifier NULL,
    [TipoLogradouro] int NOT NULL,
    [TipoResidencia] int NOT NULL,
    CONSTRAINT [PK_EnderecoCobrancaModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EnderecoCobrancaModel_CidadeModel_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [CidadeModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EnderecoEntregaModel] (
    [Id] uniqueidentifier NOT NULL,
    [Justificativa] nvarchar(max) NULL,
    [Numero] int NOT NULL,
    [Bairro] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [CEP] int NOT NULL,
    [CidadeId] uniqueidentifier NULL,
    [TipoLogradouro] int NOT NULL,
    CONSTRAINT [PK_EnderecoEntregaModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EnderecoEntregaModel_CidadeModel_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [CidadeModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ClienteModel] (
    [Id] uniqueidentifier NOT NULL,
    [Justificativa] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [CPF] nvarchar(max) NULL,
    [Observacao] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Senha] nvarchar(max) NULL,
    [TelefoneId] int NULL,
    [EnderecoCobrancaId] uniqueidentifier NULL,
    [EnderecoEntregaId] uniqueidentifier NULL,
    [TipoUsuario] int NOT NULL,
    [TipoGenero] int NOT NULL,
    CONSTRAINT [PK_ClienteModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ClienteModel_EnderecoCobrancaModel_EnderecoCobrancaId] FOREIGN KEY ([EnderecoCobrancaId]) REFERENCES [EnderecoCobrancaModel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClienteModel_EnderecoEntregaModel_EnderecoEntregaId] FOREIGN KEY ([EnderecoEntregaId]) REFERENCES [EnderecoEntregaModel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClienteModel_TelefoneModel_TelefoneId] FOREIGN KEY ([TelefoneId]) REFERENCES [TelefoneModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_CidadeModel_EstadoId] ON [CidadeModel] ([EstadoId]);

GO

CREATE INDEX [IX_ClienteModel_EnderecoCobrancaId] ON [ClienteModel] ([EnderecoCobrancaId]);

GO

CREATE INDEX [IX_ClienteModel_EnderecoEntregaId] ON [ClienteModel] ([EnderecoEntregaId]);

GO

CREATE INDEX [IX_ClienteModel_TelefoneId] ON [ClienteModel] ([TelefoneId]);

GO

CREATE INDEX [IX_EnderecoCobrancaModel_CidadeId] ON [EnderecoCobrancaModel] ([CidadeId]);

GO

CREATE INDEX [IX_EnderecoEntregaModel_CidadeId] ON [EnderecoEntregaModel] ([CidadeId]);

GO

CREATE INDEX [IX_EstadoModel_PaisId] ON [EstadoModel] ([PaisId]);

GO

ALTER TABLE [Livros] ADD CONSTRAINT [FK_Livros_Parametro_PrecificacaoId] FOREIGN KEY ([PrecificacaoId]) REFERENCES [Parametro] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200909000537_Atualizacao07', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Parametro] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [PaisModel] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Livros] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [EstadoModel] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [EnderecoEntregaModel] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [EnderecoCobrancaModel] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [ClienteModel] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [CidadeModel] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Categoria] ADD [StatusAtual] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200909001222_Atualizacao08', N'2.2.6-servicing-10079');

GO

CREATE TABLE [CartaoCreditoModel] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [NumeroCartao] VARCHAR(MAX) NULL,
    [Nome] VARCHAR(MAX) NULL,
    [CodigoSeguranca] int NOT NULL,
    [Bandeira] int NOT NULL,
    [Principal] bit NOT NULL,
    CONSTRAINT [PK_CartaoCreditoModel] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [LoginModel] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Email] VARCHAR(MAX) NULL,
    [Senha] VARCHAR(MAX) NULL,
    CONSTRAINT [PK_LoginModel] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PaisModel] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Nome] VARCHAR(MAX) NULL,
    CONSTRAINT [PK_PaisModel] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Parametro] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Nome] VARCHAR(MAX) NULL,
    [Valor] float NOT NULL,
    [Tipo] int NOT NULL,
    CONSTRAINT [PK_Parametro] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TelefoneModel] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [DDD] int NOT NULL,
    [Numero] int NOT NULL,
    [Tipo] int NOT NULL,
    CONSTRAINT [PK_TelefoneModel] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [EstadoModel] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Nome] VARCHAR(MAX) NULL,
    [PaisId] uniqueidentifier NULL,
    CONSTRAINT [PK_EstadoModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EstadoModel_PaisModel_PaisId] FOREIGN KEY ([PaisId]) REFERENCES [PaisModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Livro] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Titulo] VARCHAR(MAX) NULL,
    [Preco] float NOT NULL,
    [Foto] VARCHAR(MAX) NULL,
    [Descricao] VARCHAR(MAX) NULL,
    [Autor] VARCHAR(MAX) NULL,
    [Ano] int NOT NULL,
    [Editora] VARCHAR(MAX) NULL,
    [Edicao] int NOT NULL,
    [ISBN] VARCHAR(MAX) NULL,
    [Paginas] int NOT NULL,
    [Altura] float NOT NULL,
    [Largura] float NOT NULL,
    [Profundidade] float NOT NULL,
    [Peso] float NOT NULL,
    [PrecificacaoId] uniqueidentifier NULL,
    [CodigoDeBarras] VARCHAR(MAX) NULL,
    CONSTRAINT [PK_Livro] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Livro_Parametro_PrecificacaoId] FOREIGN KEY ([PrecificacaoId]) REFERENCES [Parametro] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [CidadeModel] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Nome] VARCHAR(MAX) NULL,
    [EstadoId] uniqueidentifier NULL,
    CONSTRAINT [PK_CidadeModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CidadeModel_EstadoModel_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [EstadoModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Categoria] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [NomeCategoria] VARCHAR(MAX) NULL,
    [LivrosModelId] uniqueidentifier NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Categoria_Livro_LivrosModelId] FOREIGN KEY ([LivrosModelId]) REFERENCES [Livro] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EnderecoCobrancaModel] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Numero] int NOT NULL,
    [Nome] VARCHAR(MAX) NULL,
    [Bairro] VARCHAR(MAX) NULL,
    [CEP] int NOT NULL,
    [CidadeId] uniqueidentifier NULL,
    [TipoLogradouro] int NOT NULL,
    [TipoResidencia] int NOT NULL,
    [Observacao] VARCHAR(MAX) NULL,
    [Principal] bit NOT NULL,
    CONSTRAINT [PK_EnderecoCobrancaModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EnderecoCobrancaModel_CidadeModel_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [CidadeModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EnderecoEntregaModel] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Numero] int NOT NULL,
    [Bairro] VARCHAR(MAX) NULL,
    [Nome] VARCHAR(MAX) NULL,
    [CEP] int NOT NULL,
    [CidadeId] uniqueidentifier NULL,
    [TipoLogradouro] int NOT NULL,
    [TipoResidencia] int NOT NULL,
    [Observacao] VARCHAR(MAX) NULL,
    [Principal] bit NOT NULL,
    CONSTRAINT [PK_EnderecoEntregaModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EnderecoEntregaModel_CidadeModel_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [CidadeModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Cliente] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Nome] VARCHAR(MAX) NULL,
    [CPF] VARCHAR(MAX) NULL,
    [LoginId] uniqueidentifier NULL,
    [TelefoneId] uniqueidentifier NULL,
    [DataNascimento] datetime2 NOT NULL,
    [EnderecoCobrancaId] uniqueidentifier NULL,
    [EnderecoEntregaId] uniqueidentifier NULL,
    [CartaoCreditoId] uniqueidentifier NULL,
    [TipoUsuario] int NOT NULL,
    [TipoGenero] int NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cliente_CartaoCreditoModel_CartaoCreditoId] FOREIGN KEY ([CartaoCreditoId]) REFERENCES [CartaoCreditoModel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Cliente_EnderecoCobrancaModel_EnderecoCobrancaId] FOREIGN KEY ([EnderecoCobrancaId]) REFERENCES [EnderecoCobrancaModel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Cliente_EnderecoEntregaModel_EnderecoEntregaId] FOREIGN KEY ([EnderecoEntregaId]) REFERENCES [EnderecoEntregaModel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Cliente_LoginModel_LoginId] FOREIGN KEY ([LoginId]) REFERENCES [LoginModel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Cliente_TelefoneModel_TelefoneId] FOREIGN KEY ([TelefoneId]) REFERENCES [TelefoneModel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Categoria_LivrosModelId] ON [Categoria] ([LivrosModelId]);

GO

CREATE INDEX [IX_CidadeModel_EstadoId] ON [CidadeModel] ([EstadoId]);

GO

CREATE INDEX [IX_Cliente_CartaoCreditoId] ON [Cliente] ([CartaoCreditoId]);

GO

CREATE INDEX [IX_Cliente_EnderecoCobrancaId] ON [Cliente] ([EnderecoCobrancaId]);

GO

CREATE INDEX [IX_Cliente_EnderecoEntregaId] ON [Cliente] ([EnderecoEntregaId]);

GO

CREATE INDEX [IX_Cliente_LoginId] ON [Cliente] ([LoginId]);

GO

CREATE INDEX [IX_Cliente_TelefoneId] ON [Cliente] ([TelefoneId]);

GO

CREATE INDEX [IX_EnderecoCobrancaModel_CidadeId] ON [EnderecoCobrancaModel] ([CidadeId]);

GO

CREATE INDEX [IX_EnderecoEntregaModel_CidadeId] ON [EnderecoEntregaModel] ([CidadeId]);

GO

CREATE INDEX [IX_EstadoModel_PaisId] ON [EstadoModel] ([PaisId]);

GO

CREATE INDEX [IX_Livro_PrecificacaoId] ON [Livro] ([PrecificacaoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200911235330_Atualizao09', N'2.2.6-servicing-10079');

GO

