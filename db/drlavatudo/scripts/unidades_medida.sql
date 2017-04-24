CREATE TABLE [dbo].[unidades_medida]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(21) NOT NULL, 
    [grandeza] CHAR(3) NOT NULL DEFAULT ('T'), 
    [simbolo] VARCHAR(6) NOT NULL, 
    [fator] NUMERIC(12, 4) NOT NULL DEFAULT (1) 
)

GO

CREATE INDEX [ix_unidades_medida] ON [dbo].[unidades_medida] ([grandeza], [simbolo]) INCLUDE ([nome])
