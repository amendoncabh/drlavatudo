CREATE TABLE [dbo].[clientes]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(100) NOT NULL, 
    [tipo] CHAR NOT NULL DEFAULT ('C'), 
    [categoria] INT NOT NULL DEFAULT (0), 
    [eh_empresa] CHAR NOT NULL DEFAULT ('N'), 
    [cpf_cnpj] VARCHAR(14) NOT NULL, 
    [logradouro] VARCHAR(120) NULL, 
    [bairro] VARCHAR(30) NULL, 
    [municipio] VARCHAR(60) NULL, 
    [codigo_postal] VARCHAR(10) NULL, 
    [unidade_federativa] CHAR(2) NULL,
    [pais] VARCHAR(30) NULL, 
    [email] VARCHAR(240) NULL, 
    [telefone_fixo] VARCHAR(15) NULL, 
    [telefone_movel] VARCHAR(15) NULL, 
    [situacao] CHAR(1) NOT NULL DEFAULT ('A'), 
    CONSTRAINT [fk_clientes_categoria] FOREIGN KEY ([categoria]) REFERENCES [categorias]([codigo])
)
GO

CREATE INDEX [ix_clientes_1] ON [dbo].[clientes] ([nome], [tipo]) INCLUDE ( [categoria] )

GO

CREATE INDEX [ix_clientes_2] ON [dbo].[clientes] ([nome], [categoria]) INCLUDE ([tipo])

GO

CREATE INDEX [ix_clientes_3] ON [dbo].[clientes] ([nome], [cpf_cnpj]) INCLUDE ([tipo], [categoria])

GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'É Empresa?',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'clientes',
    @level2type = N'COLUMN',
    @level2name = 'eh_empresa'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'clientes',
    @level2type = N'COLUMN',
    @level2name = 'tipo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Categoria',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'clientes',
    @level2type = N'COLUMN',
    @level2name = 'categoria'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nome',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'clientes',
    @level2type = N'COLUMN',
    @level2name = 'nome'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identificador',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'clientes',
    @level2type = N'COLUMN',
    @level2name = 'codigo'

