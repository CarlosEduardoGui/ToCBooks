IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

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

CREATE TABLE [Cliente] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Nome] VARCHAR(MAX) NULL,
    [CPF] VARCHAR(MAX) NULL,
    [TelefoneId] uniqueidentifier NULL,
    [DataNascimento] datetime2 NOT NULL,
    [TipoUsuario] int NOT NULL,
    [TipoGenero] int NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cliente_TelefoneModel_TelefoneId] FOREIGN KEY ([TelefoneId]) REFERENCES [TelefoneModel] ([Id]) ON DELETE NO ACTION
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

CREATE TABLE [CartaoCredito] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [NumeroCartao] VARCHAR(MAX) NULL,
    [Nome] VARCHAR(MAX) NULL,
    [CodigoSeguranca] int NOT NULL,
    [Bandeira] int NOT NULL,
    [DataVencimento] datetime2 NOT NULL,
    [Principal] bit NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_CartaoCredito] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CartaoCredito_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Login] (
    [Id] uniqueidentifier NOT NULL,
    [StatusAtual] int NOT NULL,
    [Justificativa] VARCHAR(MAX) NULL,
    [Email] VARCHAR(MAX) NULL,
    [Senha] VARCHAR(MAX) NULL,
    [TipoUsuario] int NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Login_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EnderecoCobranca] (
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
    [ClienteId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_EnderecoCobranca] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EnderecoCobranca_CidadeModel_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [CidadeModel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EnderecoCobranca_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EnderecoEntrega] (
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
    [ClienteId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_EnderecoEntrega] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EnderecoEntrega_CidadeModel_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [CidadeModel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EnderecoEntrega_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_CartaoCredito_ClienteId] ON [CartaoCredito] ([ClienteId]);

GO

CREATE INDEX [IX_Categoria_LivrosModelId] ON [Categoria] ([LivrosModelId]);

GO

CREATE INDEX [IX_CidadeModel_EstadoId] ON [CidadeModel] ([EstadoId]);

GO

CREATE INDEX [IX_Cliente_TelefoneId] ON [Cliente] ([TelefoneId]);

GO

CREATE INDEX [IX_EnderecoCobranca_CidadeId] ON [EnderecoCobranca] ([CidadeId]);

GO

CREATE INDEX [IX_EnderecoCobranca_ClienteId] ON [EnderecoCobranca] ([ClienteId]);

GO

CREATE INDEX [IX_EnderecoEntrega_CidadeId] ON [EnderecoEntrega] ([CidadeId]);

GO

CREATE INDEX [IX_EnderecoEntrega_ClienteId] ON [EnderecoEntrega] ([ClienteId]);

GO

CREATE INDEX [IX_EstadoModel_PaisId] ON [EstadoModel] ([PaisId]);

GO

CREATE INDEX [IX_Livro_PrecificacaoId] ON [Livro] ([PrecificacaoId]);

GO

CREATE UNIQUE INDEX [IX_Login_ClienteId] ON [Login] ([ClienteId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200914160830_Banco', N'2.2.6-servicing-10079');

GO

