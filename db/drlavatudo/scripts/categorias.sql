CREATE TABLE [dbo].[categorias]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [tipo] CHAR NOT NULL DEFAULT ('C'), 
    [nome] VARCHAR(30) NOT NULL, 
    [codigo_pai] INT NULL, 
    CONSTRAINT [fk_categorias_categoria] FOREIGN KEY (codigo_pai) REFERENCES [categorias]([codigo])
)
GO

CREATE INDEX [ix_categorias_1] ON [dbo].[categorias] ([nome],[tipo])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identificador',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'categorias',
    @level2type = N'COLUMN',
    @level2name = 'codigo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nome',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'categorias',
    @level2type = N'COLUMN',
    @level2name = 'nome'
GO

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Pai',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'categorias',
    @level2type = N'COLUMN',
    @level2name = 'codigo_pai'
GO
