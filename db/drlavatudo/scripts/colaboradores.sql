CREATE TABLE [dbo].[colaboradores]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(100) NOT NULL, 
    [tipo] CHAR NOT NULL DEFAULT ('F'), 
    [categoria] INT NOT NULL, 
    [cpf] VARCHAR(11) NOT NULL, 
    [logradouro] VARCHAR(120) NULL, 
    [bairro] VARCHAR(30) NULL, 
    [municipio] VARCHAR(60) NULL, 
    [codigo_postal] VARCHAR(10) NULL, 
    [unidade_federativa] CHAR(2) NULL,
    [pais] VARCHAR(30) NULL, 
    [email] VARCHAR(240) NULL, 
    [telefone_fixo] VARCHAR(15) NULL, 
    [telefone_movel] VARCHAR(15) NULL, 
    [comissao] DECIMAL(5, 2) NOT NULL DEFAULT (0), 
    [situacao] CHAR(1) NULL DEFAULT ('A'), 
    CONSTRAINT [fk_colaboradores_categorias] FOREIGN KEY ([categoria]) REFERENCES [categorias]([codigo])
)

GO

CREATE INDEX [ix_colaboradores_1] ON [dbo].[colaboradores] ([nome], [tipo]) INCLUDE ([categoria])

GO

CREATE INDEX [ix_colaboradores_2] ON [dbo].[colaboradores] ([nome], [categoria]) INCLUDE ([tipo])

GO

CREATE INDEX [ix_colaboradores_3] ON [dbo].[colaboradores] ([nome], [cpf]) INCLUDE ([tipo], [categoria])
