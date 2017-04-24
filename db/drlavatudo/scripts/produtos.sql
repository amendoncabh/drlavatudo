CREATE TABLE [dbo].[produtos]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(60) NOT NULL, 
    [descricao] TEXT NOT NULL, 
    [tipo] CHAR NOT NULL DEFAULT ('S'), 
    [categoria] INT NOT NULL DEFAULT (0), 
    [unidade_medida] INT NOT NULL DEFAULT (0), 
    [quantidade] NUMERIC(12, 4) NOT NULL DEFAULT (1), 
    [preco] MONEY NOT NULL DEFAULT (0), 
    [comissao] DECIMAL(5, 2) NOT NULL DEFAULT (0), 
    CONSTRAINT [fk_produtos_unidades_medida] FOREIGN KEY ([unidade_medida]) REFERENCES [unidades_medida]([codigo])
)
