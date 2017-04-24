CREATE TABLE [dbo].[listas_preco]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARBINARY(30) NOT NULL, 
    [descricao] TEXT NULL, 
    [tipo] CHAR NOT NULL DEFAULT ('N'), 
    [categoria] INT NOT NULL, 
    [validade_de] SMALLDATETIME NOT NULL DEFAULT (GETDATE()), 
    [validade_ate] SMALLDATETIME NOT NULL DEFAULT (DATEADD(day,1,GETDATE())), 
    [condicao] TEXT NULL, 
    [situacao] CHAR NOT NULL DEFAULT ('A'), 
    CONSTRAINT [fk_listas_preco_categorias] FOREIGN KEY ([categoria]) REFERENCES [categorias]([codigo])
)

GO

CREATE INDEX [ix_listas_preco_1] ON [dbo].[listas_preco] ([validade_de], [validade_ate], [tipo], [situacao]) INCLUDE ([nome], [categoria])

GO

CREATE INDEX [ix_listas_preco_2] ON [dbo].[listas_preco] ([validade_de], [validade_ate], [categoria], [situacao]) INCLUDE ([nome], [tipo])

