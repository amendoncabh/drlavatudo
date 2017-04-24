CREATE TABLE [dbo].[regioes]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(30) NOT NULL, 
    [codigo_postal_de] VARCHAR(10) NOT NULL, 
    [codigo_postal_ate] VARCHAR(10) NOT NULL, 
    [municipio] VARCHAR(60) NOT NULL DEFAULT (''), 
    [unidade_federativa] CHAR(2) NOT NULL
)

GO

CREATE INDEX [ix_regioes_codigo_postal] ON [dbo].[regioes] ([unidade_federativa], [codigo_postal_de], [codigo_postal_ate])
