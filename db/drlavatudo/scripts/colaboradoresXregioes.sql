CREATE TABLE [dbo].[colaboradoresXregioes]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [colaborador] INT NOT NULL, 
    [regiao] INT NOT NULL, 
    [situacao] CHAR(1) NOT NULL DEFAULT ('A'), 
    CONSTRAINT [fk_colaboradoresXregioes] FOREIGN KEY ([colaborador]) REFERENCES [colaboradores]([codigo]), 
    CONSTRAINT [fk_regioesXcolaboradores] FOREIGN KEY ([regiao]) REFERENCES [regioes]([codigo])
)

GO

CREATE UNIQUE INDEX [ux_colaboradoresXregioes] ON [dbo].[colaboradoresXregioes] ([colaborador], [regiao], [situacao])

GO

CREATE INDEX [ix_regioesXcolaboradores] ON [dbo].[colaboradoresXregioes] ([regiao], [colaborador], [situacao])
